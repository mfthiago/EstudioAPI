import  { useEffect, useState } from 'react';
import axios from 'axios';
import AccountNavigation from '../AccountNavigation';
import {Navigate} from 'react-router-dom';
import {useParams} from 'react-router-dom';

export default function EstudiosFormPage(){
    const {id} = useParams();
    console.log({id});
    const[nome,setNome] = useState('');
    const[telefone,setTelefone] = useState('');
    const[endereco,setEndereco] = useState('');
    const[checkIn,setCheckIn] = useState('');
    const[checkOut,setCheckOut] = useState('');
    const[redirect,setRedirect] = useState(false);

    useEffect(() => {
        if(!id){
            return;
        }
        axios.get('/Estudio/'+id).then(response =>{
            const {data} = response;
            setNome(data.nome);
            setTelefone(data.telefone);
            setEndereco(data.endereco);
            setCheckIn(data.checkIn);
            setCheckOut(data.checkOut);
        });
    }, [id]);

    async function addEstudio(ev){
        ev.preventDefault();
        const estudioData= {
            nome,telefone,
            endereco,checkIn,checkOut
        }
        if(id){
            await axios.put('/Estudio/'+id, {
                id, ...estudioData
            });
            setRedirect(true);
            

        }else{
            await axios.post('/Estudio', estudioData);
            setRedirect(true);
        }
        
    }

    if(redirect){
        return <Navigate to={'/account/estudios'} />
    }

    return(
        <div>
            <AccountNavigation />
                    <form onSubmit={addEstudio}>
                        <h2 className="text-2xl mt-4">Nome</h2>
                        <input type="text" value={nome} onChange={ev => setNome(ev.target.value)} placeholder="Nome do Estúdio"/>
                        <h2 className="text-2xl mt-4">Contato</h2>
                        <input type="text" value={telefone} onChange={ev => setTelefone(ev.target.value)} placeholder="(DDD) 99999-0000"/>
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
                            <div>
                                <h3 className="mt-2 -mb-1">Preço</h3>
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
    );
}