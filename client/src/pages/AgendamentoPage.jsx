import React, { useEffect } from 'react';
import {Link, useParams} from 'react-router-dom';
import AccountNavigation from '../AccountNavigation';
import axios from 'axios';
import {useState} from 'react';
import EnderecoLink from "../EnderecoLink";
import EstudioGallery from "../EstudioGallery";
import AgendamentoDates from '../AgendamentoDates';

export default function AgendamentoPage(){
    const{id} = useParams();
    const [agendamento, setAgendamento] = useState(null);
    const [estudio, setEstudio] = useState(null);
    
    useEffect(() => {
        if (id) {
            axios.get(`/Agendamento/${id}`).then(response => {
                const agendamentoData = response.data;
                setAgendamento(agendamentoData);
                console.log(agendamentoData);

                // Agora que temos o agendamento, buscamos o estúdio relacionado
                if (agendamentoData?.estudioId) {
                    axios.get('/Estudio').then(response => {
                        const estudioData = response.data.find(est => est.id === agendamentoData.estudioId);
                        setEstudio(estudioData);
                        console.log(estudioData);
                    });
                }
            });
        }
    }, [id]);

    if(!agendamento){
        return '';
    }
    

    return(

        <div className="my-8">
            <h1 className="text-3xl">{estudio?.nome}</h1>
            <EnderecoLink className="my-2 block">
                {estudio?.endereco}
            </EnderecoLink>
            <div className="bg-gray-200 p-6 my-6 rounded-2xl flex items-center justify-between">
                <div>    
                <h2 className="text-2xl mb-4">Informações do seu agendamento:</h2>
                <AgendamentoDates agendamento={agendamento}/>
                </div>
                <div className='bg-primary p-4 text-white rounded-2xl'>
                    <div>Preço total:</div> 
                    <div className='text-3xl'>R$ {agendamento.preco}</div>
                </div>
            </div>
            <EstudioGallery estudio={estudio}/>
        </div>
    )
}