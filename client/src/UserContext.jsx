import {createContext, useEffect, useState} from "react";
import axios from "axios";
import {data} from "autoprefixer";

export const UserContext = createContext({});

export function UserContextProvider({children}) {
  const [user,setUser] = useState(null);
  const [ready,setReady] = useState(false);
  useEffect(() => {
    const user = localStorage.getItem("user");
    if (user) {
      setUser(JSON.parse(user));
      axios.defaults.headers.common["Authorization"] = "Bearer " + token;
    }
    setReady(true);
  }, []);
  return (
    <UserContext.Provider value={{user,setUser,ready}}>
      {children}
    </UserContext.Provider>
  );
}