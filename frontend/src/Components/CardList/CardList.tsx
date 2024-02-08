import React from "react";
import Card from "../Card/Card";
import { CompanySearch } from "../../company";
import {v4 as uuid4} from "uuid";

interface Props {
  searchResult: CompanySearch[];
}

const CardList: React.FC<Props> = ({searchResult}: Props): JSX.Element => {
  return <>
  {searchResult.length > 0 ? (
    searchResult.map((result)=>{
      return <Card id={result.symbol} key={uuid4()} searchResult={result}/>
    })
  ):(<h1>No Result</h1>) }
  </>;
};
export default CardList;
