import React from "react";

interface Props {
  companyName: string;
  ticker: string;
  price: number;
}

const Card: React.FC<Props> = (props: Props) : JSX.Element => {
  return (
    <div className="card">
      <img
        src="http://images.unsplash.com/photo-1612428978260-2b9c7df20150?ixl"
        alt="Image"
      />
      <div className="details">
        <h2>
          {props.companyName} ({props.ticker})
        </h2>
        <p>{props.price}</p>
      </div>
      <p className="infon">
        Lorem ipsum, dolor sit amet consectetur adipisicing elit. Magnam,
        dignissimos!
      </p>
    </div>
  );
};

export default Card;
