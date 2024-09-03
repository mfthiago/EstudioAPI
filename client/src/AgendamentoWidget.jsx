import { useContext, useEffect, useState } from "react";
import { differenceInCalendarDays } from "date-fns";
import axios from "axios";
import { UserContext } from "./UserContext";
import { Link } from "react-router-dom";
import { useParams } from "react-router-dom";
import { Navigate } from "react-router-dom";

export default function AgendamentoWidget({ estudio }) {
  const [dataInicial, setDataInicial] = useState("");
  const [dataFinal, setDataFinal] = useState("");
  const [contato, setContato] = useState("");
  const { user } = useContext(UserContext);
  const [redirect, setRedirect] = useState(null);
  const [nome, setNome] = useState("");
  const [userId, setUserId] = useState("");


  useEffect(() => {
    if (user) {
      setNome(user.username);
      setUserId(user.id);
    }
  });

  let numberOfDays = 0;
  if (dataInicial && dataFinal) {
    numberOfDays = differenceInCalendarDays(
      new Date(dataFinal),
      new Date(dataInicial)
    );
  }

  async function agendar() {
    if (user) {
      axios.defaults.headers.common["Authorization"] = "Bearer " + user.token;
    }

    const response = await axios.post("/Agendamento/" + estudio.id, {
      dataInicial,
      dataFinal,
      estudio: estudio.id,
      preco: numberOfDays * estudio.preco,
      appuser: nome,
      appuserid: userId,
    });

    const agendamentoId = response.data.id;

    if (agendamentoId != null) {
      alert("Agendamento feito com sucesso");
      setRedirect("/account/agendamentos/" + agendamentoId);
    }
    else{
      alert("Erro ao fazer agendamento");
    }
  }

  if (redirect) {
    return <Navigate to={redirect} />;
  }

  return (
    <div className="bg-white shadow p-4 rounded-2xl">
      <div className="text-2xl text-center">
        Preço: ${estudio.preco} / por dia
      </div>
      <div className="border rounded-2xl mt-4">
        <div className="flex">
          <div className="py-3 px-4">
            <label>Check In: </label>
            <input
              type="date"
              value={dataInicial}
              onChange={(ev) => setDataInicial(ev.target.value)}
            />
          </div>
          <div className="py-3 px-4 border-l">
            <label>Check Out: </label>
            <input
              type="date"
              value={dataFinal}
              onChange={(ev) => setDataFinal(ev.target.value)}
            />
          </div>
        </div>
        {numberOfDays > 0}
      </div>

      <button onClick={agendar} className="primary mt-4">
        Faça seu agendamento
        {numberOfDays > 0 && (
          <>
            <span> ${numberOfDays * estudio.preco}</span>
          </>
        )}
      </button>
    </div>
  );
}
