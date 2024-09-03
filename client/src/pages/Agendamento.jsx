import React, { useEffect } from 'react';
import {UserContext} from '../UserContext';
import {Navigate, Link, useParams} from 'react-router-dom';
import AccountNavigation from '../AccountNavigation';
import axios from 'axios';
import {useState,useContext} from 'react';
import capa from '../assets/capa.jpg';
import { set } from 'date-fns';




export default function Agendamento(){
    const{ready,user,setUser} = useContext(UserContext);
    const[redirect, setRedirect] = useState(null);
    const[agendamentos, setAgendamentos] = useState([]);
    const[estudio, setEstudio] = useState([]);
    const[estudioNome,setEstudioNome] = useState('');

    useEffect(() => {
        if (user) {
            axios.defaults.headers.common["Authorization"] = "Bearer " + user.token;
          }

        axios.get('/Agendamento/').then(response => {
            setAgendamentos(response.data);
        })
        axios.get('/Estudio/').then(response => {
            setEstudio(response.data);
        })
    },[]);

    let{subpage} = useParams();
    if(subpage === undefined){
        subpage = 'account';
    }

    if(!ready){
        return <div>Loading...</div>
    }

    if(ready && !user){
        return<Navigate to={'/login'} />
    }

    

    

    if(redirect){
        return <Navigate to={redirect} />
    }
    
    return(
        <div>
            <AccountNavigation />
            <div>
                {agendamentos?.length > 0 && agendamentos.map(agendamento => (
                    <div className='flex gap-4 bg-gray-200 rounded-2xl overflow-hidden'>
                        <div className='w-48'>
                            <img className="rounded-2xl object-cover aspect-square" src={capa} estudio={agendamento.estudio} />
                        </div>
                        <div className='py-3'>
                            <h2 className='text-xl'>{agendamento.estudioId}</h2>
                            {agendamento.dataInicial} - {agendamento.dataFinal}
                        </div>
                    </div>
                ))}
                 
            </div>
        </div>
        
    )
}