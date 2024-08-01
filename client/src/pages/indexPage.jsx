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
            <Link to={'/estudio/'+estudio.id}>
            <div className="bg-gray-500 mb-2 rounded-2xl flex">
                <img className="rounded-2xl object-cover aspect-square" src={capa} />
            </div>
              <h3 className="font-bold">{estudio.endereco}</h3>
              <h2 className="text-sm text-gray-500">{estudio.nome}</h2>
              <p className="text-sm text-gray-500">{estudio.descricao}</p>
              <span className="font-bold">${estudio.preco}</span> Por Dia
            </Link>
        ))}
    </div>
  );
}