import axios from "axios";
import { AgendamentoGet, AgendamentoPost } from "../Models/Agendamento";
import { handleError } from "../Helpers/ErrorHandler";

const api = "http://localhost:8080/api/agendamento";

export const agendamentoAddApi = async (userName: string ) => {
  try{
    const data = await axios.post<AgendamentoPost>(api + `?userName=${userName}`);
    return data;
} catch (error) {
    handleError(error);
  }
};

export const agendamentoGetApi = async () => {
  try{
    const data = await axios.get<AgendamentoGet[]>(api);
    return data;
  } catch (error) {
    handleError(error);
  }
};

export const agendamentoDeleteApi = async (id: number) => {
  try{
    const data = await axios.delete<AgendamentoPost>(api + `?id=${id}`);
    return data;
  } catch (error) {
    handleError(error);
  }
};
