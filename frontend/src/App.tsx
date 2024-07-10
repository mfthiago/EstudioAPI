import { ChangeEvent, SyntheticEvent, useState } from "react";
import "./App.css";
import CardList from "./Components/CardList/CardList";
import Search from "./Components/Search/Search";
import { searchCompanies } from "./api";
import { CompanySearch } from "./company";
import Card from "./Components/Card/Card";
import ListPorfolio from "./Portfolio/ListPortfolio/ListPorfolio";

function App() {
  const [search, setSearch] = useState<string>("");
  const [portfolioValues, setPortfolioValues] = useState<string[]>([]);
  const [searchResult, setSearchResult] = useState<CompanySearch[]>([]);
  const [serverError, setServerError] = useState<string | null>(null);
  

  const onPortfolioCreate =  (e: any) => {
    e.preventDefault();
    console.log(e);
    const updatedPortfolio = [...portfolioValues, e.target[0].value];
    setPortfolioValues(updatedPortfolio);
  }

  
  const handleSearchChange = (e: ChangeEvent<HTMLInputElement>) => {
    setSearch(e.target.value);
  };
  const onSearchSubmit = async (e: SyntheticEvent) => {
    e.preventDefault();
    const result = await searchCompanies(search);
    //setServerError(result.data);
    if (typeof result === "string") {
      setServerError(result);
    } else if (Array.isArray(result.data)) {
      setSearchResult(result.data);
    }
  };
  return (
    <div className="App">
      <Search 
      onSearchSubmit={onSearchSubmit} 
      search={search} 
      handleSearchChange={handleSearchChange} 
      />
      <ListPorfolio portfolioValues ={portfolioValues}/>
      <CardList 
      searchResults={searchResult} 
      onPortfolioCreate={onPortfolioCreate} 
      />
      {serverError && <div>Unable to connect to API</div>}
      {/* {serverError ? <div>Connected</div> : <div>Unable to connect to api</div>} */}
    </div>
  );
}
export default App;