import { Link } from "react-router-dom";
import AccountNavigation from "../AccountNavigation";
import { useEffect } from "react";
import axios from "axios";
import { useState } from "react";
import logo from '../assets/logo.png'; 
export default function MeusEstudiosPage(){

    const[estudios, setEstudios] = useState([]);
    useEffect(() => {
        axios.get('/Estudio').then(({data}) => {
            setEstudios(data);
        });
    }, [])

    return(
        <div>
            <AccountNavigation />
                <div className="text-center">
                    <Link  className="inline-flex gap-1 bg-primary text-white py-2 px-6 rounded-full" to={'/account/estudios/novo'}>
                        <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
                            <path strokeLinecap="round" strokeLinejoin="round" d="M12 4.5v15m7.5-7.5h-15" />
                        </svg>
                        Novo Estudio
                    </Link>
                </div>
                <div className="mt-4">
                    {estudios.length > 0 && estudios.map(estudio=>(
                        <Link to={'/account/estudios/'+estudio.id} className="flex  cursor-pointer gap-4 bg-gray-100 p-4 rounded-full">
                            <div className="flex w-32 h-15">
                                <img className="object-cover" src={logo} />
                            </div>
                            <div className="grow-0 shrink">
                                <h2 className="text-xl">{estudio.nome}</h2>
                                <p className="text-sm mt-2">{estudio.endereco}</p>
                                <p className="text-sm mt-2">{estudio.telefone}</p>
                            </div>
                        </Link>
                    ))}
                </div>
        </div>
    );
}