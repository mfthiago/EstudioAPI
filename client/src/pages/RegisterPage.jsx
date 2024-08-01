import { useState } from "react";
import { Link } from "react-router-dom";
import axios from 'axios';

export default function RegisterPage(){
    const[username,setName] = useState('');
    const[nome,setNome] = useState(''); 
    const[email,setEmail] = useState('');
    const[telefone,setTelefone] = useState('');    
    const[password,setPassword] = useState('');
    function registerUser(ev){
        ev.preventDefault();
        try{
            axios.post('/account/register', {
                username,
                nome,
                email,
                telefone,
                password,
            });
            if(axios.status === 200){
                alert("Registrado com sucesso")
            }
            else{
                alert("Erro ao registrar, tente de novo")
            }
        }catch(e){
            alert("Erro ao registrar, tente de novo")

        }
        
    }

    return(
        <div className="mt-4 grow flex items-center justify-around">
            <div className="mb-64">
                <h1 className="text-4xl text-center mb-4">Inscreva-se</h1>
                <form className="max-w-md mx-auto " onSubmit={registerUser}>
                    <input type="text" 
                        placeholder="Super Nome" 
                        value={username} 
                        onChange={ev => setName(ev.target.value)}/>
                    <input type="text" 
                        placeholder="Nome Completo" 
                        value={nome} 
                        onChange={ev => setNome(ev.target.value)}/>
                    <input type="email" 
                        placeholder='superemail@email.com'
                        value={email}
                        onChange={ev => setEmail(ev.target.value)}/>
                    <input type="text" 
                        placeholder='(99) 99999-9999'
                        value={telefone}
                        onChange={ev => setTelefone(ev.target.value)}/>
                    <input type="password" 
                        placeholder='Senha'
                        value={password}
                        onChange={ev => setPassword(ev.target.value)}
                    />
                    <button className="primary">Inscreva-se</button>
                    <div className="text-center py-2 text-gray-500">
                        Já é um membro? 
                        <Link className="underline text-black" to={'/login'}> Entre na sua conta</Link>
                    </div>
                </form>
            </div>
        </div>
    );
}