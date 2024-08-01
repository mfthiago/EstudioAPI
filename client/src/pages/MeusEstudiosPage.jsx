import { Link } from "react-router-dom";
import {Navigate, useParams } from "react-router-dom";
import { useState } from "react";
import axios from "axios";

export default function MeusEstudiosPage(){
    const{action} = useParams();
    const[nome,setNome] = useState('');
    const[contato,setContato] = useState('');
    const[endereco,setEndereco] = useState('');
    const[checkIn,setCheckIn] = useState('');
    const[checkOut,setCheckOut] = useState('');
    const[redirectToEstudioList,setRedirectEstudioList] = useState(false);

    async function addNovoEstudio(ev){
        ev.preventDefault();
        await axios.post('/Estudio', {
            nome,contato,endereco,checkIn,checkOut
        });
        setRedirectEstudioList(true);
    }

    if(redirectToEstudioList && !action ){
        return <Navigate to={'account/estudios'} />
    }

    return(
        <div>
            {action !== 'novo' && (
        
                <div className="text-center">
                    <Link  className="inline-flex gap-1 bg-primary text-white py-2 px-6 rounded full" to={'/account/estudios/novo'}>
                        <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
                            <path strokeLinecap="round" strokeLinejoin="round" d="M12 4.5v15m7.5-7.5h-15" />
                        </svg>
                    Novo Estudio
                    </Link>
                </div>

            )}
            {action === 'novo' && (
                <div>
                    <form onSubmit={addNovoEstudio}>
                        <h2 className="text-2xl mt-4">Nome</h2>
                        <input type="text" value={nome} onChange={ev => setNome(ev.target.value)} placeholder="Nome do Estúdio"/>
                        <h2 className="text-2xl mt-4">Contato</h2>
                        <input type="text" value={contato} onChange={ev => setContato(ev.target.value)} placeholder="(DDD) 99999-0000"/>
                        <h2 className="text-2xl mt-4">Endereço</h2>
                        <input type="text" value={endereco} onChange={ev => setEndereco(ev.target.value)} placeholder="Endereço"/>
                        <h2 className="text-2xl mt-4">Check In&Out</h2>
                        <p className="text-gray-500 text-sm"></p>
                        <div className="grid gap-2 sm:grid-cols-2">
                            <div>
                                <h3 className="mt-2 -mb-1">Check-In</h3>
                                <input type="text" value={checkIn} onChange={ev => setCheckIn(ev.target.value)} placeholder="14:00" />
                            </div>
                            <div>
                                <h3 className="mt-2 -mb-1">Check-Out</h3>
                                <input type="text" value={checkOut} onChange={ev => setCheckOut(ev.target.value)} placeholder="15:00" />
                            </div>
                            
                            
                        </div>
                        <div>
                            <button className="primary my-4">
                                Salvar
                            </button>
                        </div>
                    </form>
                </div>
            )}
            
        </div>
    );
}