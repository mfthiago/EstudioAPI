import React, { useEffect } from 'react';
import {Link, useParams} from 'react-router-dom';
import AccountNavigation from '../AccountNavigation';
import axios from 'axios';
import {useState} from 'react';
import EnderecoLink from "../EnderecoLink";
import EstudioGallery from "../EstudioGallery";

export default function AgendamentoPage(){
    const{id} = useParams();
    const [agendamento, setAgendamento] = useState(null);
    const [estudio, setEstudio] = useState(null);
    
    useEffect(() => {
        if(id){
            axios.get('/Agendamento/'+id).then(response =>{
                setAgendamento(response.data);
                console.log(agendamento)
            })
            
            axios.get('/Estudio').then(response =>{
                setEstudio(response.data.find(response => response.id === agendamento?.estudioId));
                console.log(estudio);
            });
        }
    },[id]);

    if(!agendamento){
        return '';
    }
    
    

    return(

        <div className="my-8">
            <h1 className="text-3xl">{estudio.nome}</h1>
            <EnderecoLink className="my-2 block">
                {estudio.endereco}
            </EnderecoLink>
            <div className="bg-gray-200 p-4 mb-4 rounded-2xl">
                <h2 className="text-xl">Informações do seu agendamento:</h2>
                datas
            </div>
            <EstudioGallery estudio={estudio}/>
        </div>
    )
}