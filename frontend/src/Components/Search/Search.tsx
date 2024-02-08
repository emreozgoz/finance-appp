import React, { FormEvent, SyntheticEvent, useState } from "react";

interface Props {
  onClick: (e: SyntheticEvent) => void;
  search: string | undefined;
  handleChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
}

const Search: React.FC<Props> = (props: Props): JSX.Element => {
  return (
    <div>
      <input
        value={props.search}
        onChange={(e) => props.handleChange(e)}
      ></input>
      <button onClick={(e) => props.onClick(e)}></button>
    </div>
  );
};

export default Search;
