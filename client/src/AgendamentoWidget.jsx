import { useContext, useEffect, useState } from "react";
import { differenceInCalendarDays } from "date-fns";
import axios from "axios";
import { UserContext } from "./UserContext";
import { Link } from "react-router-dom";
import { useParams } from "react-router-dom";


export default function AgendamentoWidget({estudio}) {
    const[checkIn,setCheckIn] = useState('');
    const[checkOut,setCheckOut] = useState('');
    const[nome,setNome] = useState('');
    const[contato,setContato] = useState('');
    const{user} = useContext(UserContext);
    
    useEffect(() => {
        if(user){
            setNome(user.username);

        }
    })

    let numberOfDays= 0;
    if(checkIn && checkOut){
        numberOfDays = differenceInCalendarDays(new Date(checkOut),new Date (checkIn));
    }

    async function agendar(){
        const data ={
            checkIn,checkOut,
            estudio:estudio.id, 
            preco:numberOfDays * estudio.preco,
            username:user.nome
        }
        await axios.post('/Agendamento/'+estudio.id,data)
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
            <input type="date" value={checkIn} onChange={ev=>setCheckIn(ev.target.value)} />
          </div>
          <div className="py-3 px-4 border-l">
            <label>Check Out: </label>
            <input type="date"
            value={checkOut} 
            onChange={ev=>setCheckOut(ev.target.value)} />
          </div>
        </div>
        {numberOfDays>0 &&(
            <div className="py-3 px-4 border-l">
                <label>Seu nome completo: </label>
                <input type="text"
                    value={nome} 
                    onChange={ev=>setNome(ev.target.value)} />

                <label>Seu número de telefone: </label>
                <input type="text"
                    value={contato} 
                    onChange={ev=>setContato(ev.target.value)} />
                
            </div>
        )}
      </div>

      <button onClick={agendar} className="primary mt-4">
        Faça seu agendamento
        {numberOfDays>0 &&(
            <>
                <span> ${numberOfDays * estudio.preco}</span>
            </>
        )}
        </button>
    </div>
  );
}
