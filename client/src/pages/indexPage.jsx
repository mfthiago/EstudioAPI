import {useEffect, useState} from "react";
import axios from "axios";
import {Link} from "react-router-dom";
import capa from '../assets/capa.jpg'; 

export default function IndexPage() {
  const [estudios,setEstudios] = useState([]);
  useEffect(() => {
    axios.get('/Estudio').then(response => {
      setEstudios(response.data);
    });
  }, []);
  return (
    <div className="mt-8 grid gap-x-6 gap-y-8 grid-cols-2 md:grid-cols-3 lg:grid-cols-4">
        {estudios.length > 0 &&
        estudios.map(estudio => (
            <div>
            <div className="bg-gray-500 mb-2 rounded-2xl flex">
                <img className="rounded-2xl object-cover aspect-square" src={capa} />
            </div>
                <h2 className="text-sm truncate">{estudio.nome}</h2>
                <h3 className="font-bold">{estudio.endereco}</h3>
            </div>
        ))}
    </div>
  );
}