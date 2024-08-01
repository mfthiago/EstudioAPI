import React, {useContext} from 'react';
import {UserContext} from '../UserContext';
import {Navigate, Link, useParams} from 'react-router-dom';
import axios from 'axios';
import {useState} from 'react';
import MeusEstudiosPage from './MeusEstudiosPage';
import AccountNavigation from '../AccountNavigation';

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

    

    

    if(redirect){
        return <Navigate to={redirect} />
    }

    return(
        <div>
            <AccountNavigation />
            {subpage === 'account' &&(
                <div className='text-center max-w-lg mx-auto'>
                    Logado como {user.userName} ({user.email})<br/>
                    <button 
                    onClick={logout} 
                    className='primary max-w-sm mt-2'>
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