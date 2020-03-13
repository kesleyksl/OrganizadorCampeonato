import { Usuario } from "./usuario";

export class Fase {
  id: number;
  campeonatoId: number;
  data: any;
  tipoFaseId: number;
  tipoFase: any;
  nome: string;
  competidores: Usuario[];
  musicas: Usuario[];
  jurados: Usuario[];
}
