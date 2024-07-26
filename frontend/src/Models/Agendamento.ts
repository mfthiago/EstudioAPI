export type AgendamentoGet = {
    id: number;
    data: string;
    hora: string;
    estudio: string;
    sala: string
    preco: number;

}

export type AgendamentoPost ={
    data: string;
    hora: string;
    estudio: string;
    sala: string;
    preco: number;

}