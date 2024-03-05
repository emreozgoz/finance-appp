import React from "react";
import Table from "../../Components/Table/Table";
import RatioList from "../../Components/RatioList/RatioList";
import { CompanyKeyMetrics } from "../../company";
import { testIncomeStatementData } from "../../Components/Table/testData";

type Props = {};
const tableConfig = [
  {
    label: "Market Cap",
    render: (company: any) => company.marketCapTTM,
    subTitle: "Total value of all a company's shares of stock",
  },
];
const DesignPage = (props: Props) => {
  return (
    <>
      <h1>Design Page</h1>
      <h2>
        Lorem ipsum, dolor sit amet consectetur adipisicing elit. Dolor repellat
        fugit, reprehenderit quasi ipsum aperiam vitae tenetur culpa debitis
        temporibus pariatur accusantium, corporis, officia maxime tempore
        numquam sapiente id voluptates.
      </h2>
      <RatioList data={testIncomeStatementData} config ={tableConfig}/>
      <Table data={testIncomeStatementData} config={tableConfig} />
    </>
  );
};

export default DesignPage;
