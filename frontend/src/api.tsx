import axios from "axios";
import { CompanySearch } from "./company";
interface SearchResponse {
  data: CompanySearch[];
}
export const searchCompanies = async (query: string) => {
  try {
    var data = await axios.get<SearchResponse>(
      `https://financialmodelingprep.com/api/v3/search-ticker?query=${query}&limit=10&exchange=NASDAQ&apikey=${process.env.REACT_APP_API_KEY}`
    );
    return data;
  } catch (error) {
    if (axios.isAxiosError(error)) {
      console.log("error message: " + error);
      return error.message;
    } else {
      console.log("unexpected error: " + error);
      return "hata";   
    }
  }
};
