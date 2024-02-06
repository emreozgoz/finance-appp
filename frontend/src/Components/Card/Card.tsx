import React from "react";

type Props = {};

const Card = (props: Props) => {
  return (
    <div className="card">
      <img
        src="http://images.unsplash.com/photo-1612428978260-2b9c7df20150?ixl"
        alt="Image"
      />
      <div className="details">
        <h2>AAPL</h2>
        <p>$110</p>
      </div>
    </div>
  );
};

export default Card;
