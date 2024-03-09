import React, { SyntheticEvent } from "react";
import { CompanySearch } from "../../company";
import AddPortfolio from "../Portfolio/AddPortfolio/AddPortfolio";
import { Link } from "react-router-dom";

interface Props {
  id: string;
  searchResult: CompanySearch;
  onPortfolioCreate: (e: SyntheticEvent) => void;
  imageUrl: string;
}

const Card: React.FC<Props> = ({
  id,
  searchResult,
  onPortfolioCreate,
  imageUrl,
}: Props): JSX.Element => {
  return (
    <div
      className="inline-block flex-col w-full p-4 space-y-4 text-center rounded-lg shadow-lg md:w-auto ml-6 mb-4 bg-slate-500"
      key={id}
      id={id}
    >
      <Link
        to={`/company/${searchResult.symbol}/company-profile`}
        className="font-bold text-center text-veryDarkViolet md:text-left text-sm"
      >
        {searchResult.name} ({searchResult.symbol})
      </Link>
      <img src={imageUrl} />
      <p className="text-sm text-gray-600">{searchResult.currency}</p>
      <p className="font-bold text-sm text-black">
        {searchResult.exchangeShortName} - {searchResult.stockExchange}
      </p>
      <AddPortfolio
        onPortfolioCreate={onPortfolioCreate}
        symbol={searchResult.symbol}
      />
    </div>
  );
};

export default Card;
