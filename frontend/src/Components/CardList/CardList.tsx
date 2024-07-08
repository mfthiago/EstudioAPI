import React from 'react'
import Card from '../Card/Card'

interface Props {}

const CardList : React.FC<Props> = (props: Props): JSX.Element => {
  return (
    <div>
        <Card nome='Sim ' preco={100} info='simsim'/>
        <Card nome='Nao ' preco={300} info='naosim'/>
        <Card nome='Simsim ' preco={900} info='simnao'/>

    </div>
  )
}

export default CardList