import { Campeonato } from "../../modelo/Campeonato";



export class LojaCarrinhoCompras {
  public campeonatos: Campeonato[] = [];
  public adicionar(campeonato: Campeonato) {
    var campeonatoLocalStorage = localStorage.getItem("campeonatoStorage");
    if (!campeonatoLocalStorage) {
      this.campeonatos.push(campeonato);

    }
    else {
      this.campeonatos = JSON.parse(campeonatoLocalStorage);
      this.campeonatos.push(campeonato);

    }
    localStorage.setItem("campeonatoStorage", JSON.stringify(this.campeonatos));

  }

  public obterCampeonatos(): Campeonato[]{
    var campeonatoLocalStorage = localStorage.getItem("campeonatoStorage");
    if (campeonatoLocalStorage) {
      return JSON.parse(campeonatoLocalStorage)
    }


  }

  public removerCampeonato(campeonato: Campeonato) {
   
  }
}
