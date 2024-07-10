import React from 'react'
import CardPortfolio from '../CardPortfolio/CardPortfolio';

interface Props {
    portfolioValues : string[];
}

const ListPorfolio = ({portfolioValues}: Props) => {
  return <>
  <h3>My Portfolio</h3>
  <ul>
    {portfolioValues &&
        portfolioValues.map((portfolioValue) =>{
            return <CardPortfolio portfolioValue={portfolioValue} />
        })
    }
  </ul>
  </>
};

export default ListPorfolio