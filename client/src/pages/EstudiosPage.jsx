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

export default function EstudiosPage(){
    const{id} = useParams();
    const[estudio, setEstudio] = useState(null);
    const[mostrarTodasFotos, setMostrarTodasFotos] = useState(false);

    useEffect(() => {
        if(!id){
            return;
        }
        axios.get('/Estudio/'+id).then(response => {
            setEstudio(response.data)
        });
    
    }, [id]);

    if(!estudio) return 'null';

    if(mostrarTodasFotos){
        return(
            <div className="absolute inset-0 bg-black text-white min-h-screen">
                <div className="bg-black p-8 grid gap-4">
                    <div>
                        <h2 className="text-3xl">Fotos de {estudio.nome}</h2>
                        <button onClick={() => setMostrarTodasFotos(false)} className="fixed right-12 top-8 flex gap-1 py-2 px-4 rounded-2xl shadow shadow-black bg-white text-black ">
                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
                                <path strokeLinecap="round" strokeLinejoin="round" d="M6 18 18 6M6 6l12 12" />
                            </svg>

                        Fechar fotos
                        </button>
                    </div>
                    <div>
                        <img src={capa}/>
                    </div>
                    <div>
                        <img src={enema} />
                    </div>
                    <div>
                        <img src={frogstomp} />
                    </div>
                    <div>
                        <img src={bloodsugar}/>
                    </div>
                    <div>
                        <img src={nevermind} />
                    </div>
                    <div>
                        <img src={cbjr} />
                    </div>
                </div>
            </div>
        )
    }

    return(
        <div className="mt-4 bg-gray-100 -mx-8 px-8 pt-8 ">
            <h1 className="text-3xl">{estudio.nome}</h1>
            <a target="_blank" className="flex my-3 block font-semibold underline" 
                href={"https://maps.google.com/?q="
                +estudio.endereco}>
                <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
                    <path strokeLinecap="round" strokeLinejoin="round" d="M15 10.5a3 3 0 1 1-6 0 3 3 0 0 1 6 0Z" />
                    <path strokeLinecap="round" strokeLinejoin="round" d="M19.5 10.5c0 7.142-7.5 11.25-7.5 11.25S4.5 17.642 4.5 10.5a7.5 7.5 0 1 1 15 0Z" />
                </svg>


                {estudio.endereco}
            </a>
            <div className="relative ">
                <div className="grid gap-2 grid-cols-[2fr_1fr] rounded-3xl overflow-hidden ">
                    <div>
                        <div>
                            <img onClick={() => setMostrarTodasFotos(true)} className="aspect-square object-cover" src={capa} />
                        </div>
                    </div>
                    <div className="grid">
                        <div>
                            <img onClick={() => setMostrarTodasFotos(true)} className="aspect-square object-cover" src={enema} />
                        </div>
                        
                        <div className="overflow-hidden">
                            <img onClick={() => setMostrarTodasFotos(true)} className="aspect-square object-cover relative top-2" src={frogstomp} />
                        </div> 
                    </div>
                </div>
            
            <button onClick={()=> setMostrarTodasFotos(true)} className="flex gap-2 absolute bottom-2 right-0 py-2 px-4 bg-white rounded-2xl shadow shadow-md shadow-gray-500">
                <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
                    <path strokeLinecap="round" strokeLinejoin="round" d="m2.25 15.75 5.159-5.159a2.25 2.25 0 0 1 3.182 0l5.159 5.159m-1.5-1.5 1.409-1.409a2.25 2.25 0 0 1 3.182 0l2.909 2.909m-18 3.75h16.5a1.5 1.5 0 0 0 1.5-1.5V6a1.5 1.5 0 0 0-1.5-1.5H3.75A1.5 1.5 0 0 0 2.25 6v12a1.5 1.5 0 0 0 1.5 1.5Zm10.5-11.25h.008v.008h-.008V8.25Zm.375 0a.375.375 0 1 1-.75 0 .375.375 0 0 1 .75 0Z" />
                </svg>
                Mais fotos
            </button>
            </div>
            <div className="mt-8 mb-8 grid gap-8 grid-cols-1 md:grid-cols-[2fr_1fr]">
                    <div>
                        <div className="my-4">
                            <h2 className="font-semibold text-2xl">Descrição</h2>
                            {estudio.descricao}
                        </div>
                        Check-In: {estudio.checkIn} <br />
                        Check-Out: {estudio.checkOut} <br />
                    </div>
                    <div>
                        <AgendamentoWidget estudio={estudio}/>
                    </div>
            </div>

        </div>

    );
}