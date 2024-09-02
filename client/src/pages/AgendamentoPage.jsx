import React from 'react';
import {Link, useParams} from 'react-router-dom';
import AccountNavigation from '../AccountNavigation';


export default function AgendamentoPage(){
    const{id} = useParams();


    return(
        <div>
            single booking: {id}
        </div>
    )
}