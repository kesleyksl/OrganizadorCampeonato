import { Usuario } from "./usuario";
import { Fase } from "./Fase";


export class Campeonato{
    id: number;
  nome: string;
  usuarioId: number;
  nomeArquivo: string;
  fases: Fase[];
  usuario: Usuario;



}
