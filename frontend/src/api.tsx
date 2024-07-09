import axios from "axios"
import { CompanySearch } from "./company";

interface SearchResponse{
    data: CompanySearch[];
}

export const searchCompanies = async (query:string) => {
    try{
        const data = await axios.get<SearchResponse>(`http://localhost:5000/search/${process.env.REACT_APP_API_KEY}/${query}`);
        return data;
        
    } catch (error){
        if(axios.isAxiosError(error)){
            console.log("error message: ", error.message)
            return error.message;
        } else{
            console.log("unexpected error: ", error)
            return "An unexpected error has occured.";
        }
    }
}