import React, { ChangeEvent, SyntheticEvent, useEffect, useState } from 'react'
import { searchCompanies } from '../../api';
import { CompanySearch } from '../../company';
import CardList from '../../Components/CardList/CardList';
import Navbar from '../../Components/Navbar/Navbar';
import ListPortfolio from '../../Components/Portfolio/ListPortfolio/ListPortfolio';
import Search from '../../Components/Search/Search';
import { AgendamentoGet } from '../../Models/Agendamento';
import { agendamentoAddApi, agendamentoDeleteApi, agendamentoGetApi } from '../../Services/AgendamentoService';
import { toast } from 'react-toastify';
import { get } from 'http';

interface Props  {}

const SearchPage = (props: Props) => {
    const [search, setSearch] = useState<string>("");
  const [portfolioValues, setPortfolioValues] = useState<AgendamentoGet[] | null>([]);
  const [searchResult, setSearchResult] = useState<CompanySearch[]>([]);
  const [serverError, setServerError] = useState<string | null>(null);

  const handleSearchChange = (e: ChangeEvent<HTMLInputElement>) => {
    setSearch(e.target.value);
  };


  useEffect(() => {
    getAgendamento();
  }, []);

  const getAgendamento = async () => {
    agendamentoGetApi()
    .then((res) =>{
      if(res?.data){
        setPortfolioValues(res?.data);
      }
    }).catch((e)=>{
      toast.warning("Erro ao buscar agendamentos");
    })
  };


  const onPortfolioCreate = (e: any) => {
    e.preventDefault();
    agendamentoAddApi(e.target[0].value)
    .then((res) => {
      if(res?.status === 204){
        toast.success("Agendamento criado com sucesso");
        getAgendamento();
      }
    }).catch((e) => {
      toast.warning("Erro ao criar agendamento");
    })
  };

  const onPortfolioDelete = (e: any) => {
    e.preventDefault();
    agendamentoDeleteApi(e.target[0].value)
    .then((res) => {
      if(res?.status === 200){
        toast.success("Agendamento deletado com sucesso");
        getAgendamento();
      }
    })
  }


  const onSearchSubmit = async (e: SyntheticEvent) => {
    e.preventDefault();
    const result = await searchCompanies(search);
    if (typeof result === "string") {
      setServerError(result);
    } else if (Array.isArray(result.data)) {
      setSearchResult(result.data);
    }
  };

  return (
    <>
      <div className="App">
        <Search
          onSearchSubmit={onSearchSubmit}
          search={search}
          handleSearchChange={handleSearchChange}
        />
        <ListPortfolio 
        portfolioValues={portfolioValues!} 
        onPortfolioDelete={onPortfolioDelete}
        />
        <CardList
          searchResults={searchResult}
          onPortfolioCreate={onPortfolioCreate}
        />
        {serverError && <div>Unable to connect to API</div>}
      </div>
    </>
  )
}

export default SearchPage