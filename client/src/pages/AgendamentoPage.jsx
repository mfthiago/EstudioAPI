import React, { useEffect } from 'react';
import {Link, useParams} from 'react-router-dom';
import AccountNavigation from '../AccountNavigation';
import axios from 'axios';
import {useState} from 'react';

export default function AgendamentoPage(){
    const{id} = useParams();
    const[agendamento, setAgendamento] = useState(null);
    useEffect(() => {
        if(id){
            axios.get('/Agendamento').then(response =>{
                const agendamentoExistente = response.data.find(agendamento => agendamento.id === id);
                if(agendamentoExistente){
                    setAgendamento(agendamentoExistente);
                }
            })
        }
    },[id]);

    return(
        <div>
            single booking: {id}
        </div>
    )
}