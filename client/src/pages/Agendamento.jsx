import React, { useEffect } from "react";
import { UserContext } from "../UserContext";
import { Navigate, Link, useParams } from "react-router-dom";
import AccountNavigation from "../AccountNavigation";
import axios from "axios";
import { useState, useContext } from "react";
import capa from "../assets/capa.jpg";
import { differenceInCalendarDays, formatDate, set } from "date-fns";
import AgendamentoDates from "../AgendamentoDates";

export default function Agendamento() {
  const { ready, user, setUser } = useContext(UserContext);
  const [redirect, setRedirect] = useState(null);
  const [agendamentos, setAgendamentos] = useState([]);
  const [estudios, setEstudios] = useState([]);

  useEffect(() => {
    if (user) {
      axios.defaults.headers.common["Authorization"] = "Bearer " + user.token;
    }

    axios.get("/Agendamento/").then((response) => {
      setAgendamentos(response.data);
    });
    axios.get('/Estudio').then((response) =>{
        setEstudios(response.data);
    })
  }, []);

  useEffect(() => {

  })

  let { subpage } = useParams();
  if (subpage === undefined) {
    subpage = "account";
  }

  if (!ready) {
    return <div>Loading...</div>;
  }

  if (ready && !user) {
    return <Navigate to={"/login"} />;
  }

  if (redirect) {
    return <Navigate to={redirect} />;
  }

  return (
    <div>
      <AccountNavigation />
      <div>
        {agendamentos?.length > 0 &&
          agendamentos.map((agendamento) => ( 
            
            <Link to ={'/account/agendamentos/'+agendamento.id} key={agendamento.id}
                className="flex gap-4 bg-gray-200 rounded-2xl overflow-hidden">
              <div className="w-48">
                <img
                  className="rounded-2xl object-cover aspect-square"
                  src={capa}
                  estudio={agendamento.estudio}
                />
              </div>
              <div className="py-3 pr-3 grow">
                <h2 className="text-xl">{agendamento.estudioId}</h2>
                
                <div className="text-xl">
                    <AgendamentoDates agendamento={agendamento}/>
                    <div className="flex gap-1 mt-1">

                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    fill="none"
                    viewBox="0 0 24 24"
                    strokeWidth={1.5}
                    stroke="currentColor"
                    className="size-8"
                  >
                    <path
                      strokeLinecap="round"
                      strokeLinejoin="round"
                      d="M2.25 18.75a60.07 60.07 0 0 1 15.797 2.101c.727.198 1.453-.342 1.453-1.096V18.75M3.75 4.5v.75A.75.75 0 0 1 3 6h-.75m0 0v-.375c0-.621.504-1.125 1.125-1.125H20.25M2.25 6v9m18-10.5v.75c0 .414.336.75.75.75h.75m-1.5-1.5h.375c.621 0 1.125.504 1.125 1.125v9.75c0 .621-.504 1.125-1.125 1.125h-.375m1.5-1.5H21a.75.75 0 0 0-.75.75v.75m0 0H3.75m0 0h-.375a1.125 1.125 0 0 1-1.125-1.125V15m1.5 1.5v-.75A.75.75 0 0 0 3 15h-.75M15 10.5a3 3 0 1 1-6 0 3 3 0 0 1 6 0Zm3 0h.008v.008H18V10.5Zm-12 0h.008v.008H6V10.5Z"
                    />
                  </svg>
                  <span className="text-xl">

                  Preço total: R${agendamento.preco}
                  </span>
                    </div>
                </div>
              </div>
            </Link>
          ))}
      </div>
    </div>
  );
}
