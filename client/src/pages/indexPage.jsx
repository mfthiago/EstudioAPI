import {useEffect, useState} from "react";
import axios from "axios";
import {Link} from "react-router-dom";

export default function IndexPage() {
  const [estudios,setEstudios] = useState([]);
  useEffect(() => {
    axios.get('/Estudio').then(response => {
      setEstudios(response.data);
    });
  }, []);
  return (
    <div className="mt-8 grid gap-x-6 gap-y-8 grid-cols-2 md:grid-cols-3 lg:grid-cols-3">
    </div>
  );
}