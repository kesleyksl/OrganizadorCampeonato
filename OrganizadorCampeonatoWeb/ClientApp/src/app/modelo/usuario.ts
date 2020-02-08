import { Campeonato } from "./Campeonato";

export class Usuario{
    id: number;
    nome: string;
    sexo: string;
    senha: string;
   
    email: string;
    telefone: string;
    campeonato: Campeonato[];
    competidor: object[];
    jurado: object[];
        //public virtual ICollection < Campeonato > Campeonatos { get; set; }
        //public virtual ICollection < Competidor > Competidores { get; set; }
        //public virtual ICollection < Jurado > Jurados { get; set; }

}
