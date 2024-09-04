import axios from "axios";
import { useEffect } from "react";
import { useParams } from "react-router-dom";
import { useState } from "react";
import capa from '../assets/capa.jpg';
import enema from '../assets/enema.jpg';
import frogstomp from '../assets/frogstomp.jpg';
import bloodsugar from '../assets/bloodsugar.jpg';
import nevermind from '../assets/nevermind.jpg';
import cbjr from '../assets/cbjr.jpg';
import AgendamentoWidget from "../AgendamentoWidget";
import EstudioGallery from "../EstudioGallery";
import EnderecoLink from "../EnderecoLink";

export default function EstudiosPage(){
    const{id} = useParams();
    const[estudio, setEstudio] = useState(null);
    

    useEffect(() => {
        if(!id){
            return;
        }
        axios.get('/Estudio/'+id).then(response => {
            setEstudio(response.data)
        });
    
    }, [id]);

    if(!estudio) return 'null';


    
    return(
        <div className="mt-4 bg-gray-100 -mx-8 px-8 py-8 ">
            <h1 className="text-3xl">{estudio.nome}</h1>
            <EnderecoLink>{estudio.endereco}</EnderecoLink>
            <EstudioGallery estudio={estudio}/>
            <div className="mt-8 mb-8 grid gap-8 grid-cols-1 md:grid-cols-2">
                <div>
                    <div className="my-4">
                        <h2 className="font-semibold text-2xl">Descrição</h2>
                        {estudio.descricao}
                    </div>
                    Check-In: {estudio.checkIn}:00 <br />
                    Check-Out: {estudio.checkOut}:00 <br />
                </div>
                <div>
                    <AgendamentoWidget estudio={estudio}/>
                </div>
            </div>
        </div>
    )
}