import React, {useContext} from 'react';
import {UserContext} from '../UserContext';
import {Navigate, Link, useParams} from 'react-router-dom';
import axios from 'axios';
import {useState} from 'react';
import MeusEstudiosPage from './MeusEstudiosPage';

export default function AccountPage(){
    const{ready,user,setUser} = useContext(UserContext);
    const[redirect, setRedirect] = useState(null);

    let{subpage} = useParams();
    if(subpage === undefined){
        subpage = 'account';
    }

    async function logout(){
        await axios.post('/account/logout')
        setUser(null);
        setRedirect('/');
    }

    if(!ready){
        return <div>Loading...</div>
    }

    if(ready && !user){
        return<Navigate to={'/login'} />
    }

    

    function linkClasses(type=null){
        let classes = 'inline-flex gap-1 py-2 px-6 rounded-full';
        if(type === subpage ){
            classes += 'inline-flex gap-1 py-2 px-6 bg-primary text-white rounded-full';
        } else{
            classes += 'inline-flex gap-1 py-2 px-6 bg-gray-200 rounded-full ';
        }
        return classes;
    }

    if(redirect){
        return <Navigate to={redirect} />
    }

    return(
        <div>
            <nav className='w-full flex justify-center mt-8 gap-4 mb-8'>
                
                <Link className={linkClasses('account')} to={'/account/'}>
                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
                        <path strokeLinecap="round" strokeLinejoin="round" d="M15.75 6a3.75 3.75 0 1 1-7.5 0 3.75 3.75 0 0 1 7.5 0ZM4.501 20.118a7.5 7.5 0 0 1 14.998 0A17.933 17.933 0 0 1 12 21.75c-2.676 0-5.216-.584-7.499-1.632Z" />
                    </svg>
                Meu perfil</Link>
                <Link className={linkClasses('agendamentos')} to={'/account/agendamentos'}>
                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
                        <path strokeLinecap="round" strokeLinejoin="round" d="M6.75 3v2.25M17.25 3v2.25M3 18.75V7.5a2.25 2.25 0 0 1 2.25-2.25h13.5A2.25 2.25 0 0 1 21 7.5v11.25m-18 0A2.25 2.25 0 0 0 5.25 21h13.5A2.25 2.25 0 0 0 21 18.75m-18 0v-7.5A2.25 2.25 0 0 1 5.25 9h13.5A2.25 2.25 0 0 1 21 11.25v7.5" />
                    </svg>

                Meus agendamentos</Link>
                <Link className={linkClasses('estudios')} to={'/account/estudios'}>
                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
                        <path strokeLinecap="round" strokeLinejoin="round" d="m9 9 10.5-3m0 6.553v3.75a2.25 2.25 0 0 1-1.632 2.163l-1.32.377a1.803 1.803 0 1 1-.99-3.467l2.31-.66a2.25 2.25 0 0 0 1.632-2.163Zm0 0V2.25L9 5.25v10.303m0 0v3.75a2.25 2.25 0 0 1-1.632 2.163l-1.32.377a1.803 1.803 0 0 1-.99-3.467l2.31-.66A2.25 2.25 0 0 0 9 15.553Z" />
                    </svg>

                Meus estudios</Link>
            </nav>
            {subpage === 'account' &&(
                <div className='text-center max-w-lg mx-auto'>
                    Logado como {user.userName} ({user.email})<br/>
                    <button 
                    onClick={logout} 
                    className='bg-primary text-white p-2 rounded-full mt-4'>
                        Logout
                    </button>
                </div>
            )}
            {subpage==='estudios'&& (
                <div>
                    <MeusEstudiosPage />
                </div>
            )}
        </div>
    )
}