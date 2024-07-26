import React, { SyntheticEvent } from "react";
import DeletePortfolio from "../DeletePortfolio/DeletePortfolio";
import { Link } from "react-router-dom";
import { AgendamentoGet } from "../../../Models/Agendamento";

interface Props {
  portfolioValue: AgendamentoGet;
  onPortfolioDelete: (e: SyntheticEvent) => void;
}

const CardPortfolio = ({ portfolioValue, onPortfolioDelete }: Props) => {
  return (
    <div className="flex flex-col w-full p-8 space-y-4 text-center rounded-lg shadow-lg md:w-1/3">
      <Link 
      to={'/company/${portfolioValue.estudio}'} className="pt-6 text-xl font-bold">
        {portfolioValue.estudio}
        </Link>
      <DeletePortfolio
        portfolioValue={portfolioValue.estudio}
        onPortfolioDelete={onPortfolioDelete}
      />
    </div>
  );
};

export default CardPortfolio;
