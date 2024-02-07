import React from "react";
import Card from "../Card/Card";

interface Props {}

const CardList = (props: Props) => {
  return (
    <div>
      <Card companyName="Apple" ticker="asd" price={120}  />
      <Card companyName="Apple1" ticker="asd1" price={121}  />
      <Card companyName="Apple2" ticker="asd2" price={122}  />
      <Card companyName="Apple3" ticker="asd3" price={123}  />
      <Card companyName="Apple4" ticker="asd4" price={124}  />
    </div>
  );
};

export default CardList;
