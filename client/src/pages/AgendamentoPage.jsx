import React, { useEffect } from 'react';
import {Link, useParams} from 'react-router-dom';
import AccountNavigation from '../AccountNavigation';
import axios from 'axios';
import {useState} from 'react';

export default function AgendamentoPage(){
    const{id} = useParams();
    const[agendamento, setAgendamento] = useState(null);
    const[estudio, setEstudio] = useState(null);
    useEffect(() => {
        if(id){
            axios.get('/Agendamento/'+id).then(response =>{
                const agendamentoExistente = response.data;
                if(agendamentoExistente){
                    setAgendamento(agendamentoExistente);
                }
            })

            /*const Agendamentos = axios.get('/Agendamento').then(response => response.data);
            console.log(Agendamentos)
            const agendamentoExistente = Agendamentos.find(({id}) => id === Agendamentos.id);
            console.log(agendamentoExistente)
            */
            axios.get('/Estudio').then(response =>{
                const estudioExistente = response.data.find(response => response.id === agendamento?.estudioId);
                console.log(estudioExistente)
                if(estudioExistente){
                    setEstudio(estudioExistente);
                }
            })
        }
    },[id]);

    if(!agendamento){
        return '';
    }
    
    

    return(

        <div>
            <h1 className="text-3xl">{estudio.nome}</h1>
        </div>
    )
}