import React, { ChangeEvent, SyntheticEvent } from "react";



interface Props {
  onClick: (e: SyntheticEvent) => void;
  search: string | undefined;
  handleChange: (e: ChangeEvent<HTMLInputElement>) => void;
  
}

const Search: React.FC<Props> = ({ onClick, handleChange, search  }:Props):JSX.Element => {
  return (
    <div>
      <input value={search} onChange={handleChange} />
      <button onClick={(e) => onClick}>Search</button>
    </div>
  );
};

export default Search;