import {createContext, useEffect, useState} from "react";
import axios from "axios";
import {data} from "autoprefixer";

export const UserContext = createContext({});

export function UserContextProvider({children}) {
  const [user,setUser] = useState(null);
  const [ready,setReady] = useState(false);
  const [token,setToken] = useState(false);

  const logout = () => {
    localStorage.removeItem("token");
    localStorage.removeItem("user");
    setUser(null);
    setToken(user.token='');
  };
  
  useEffect(() => {
    const user = localStorage.getItem("user");
    if (user) {
      setUser(JSON.parse(user));
      axios.defaults.headers.common["Authorization"] = "Bearer " + user.token;
    }
    setReady(true);
  }, []);
  return (
    <UserContext.Provider value={{user,setUser,ready}}>
      {children}
    </UserContext.Provider>
  );
}