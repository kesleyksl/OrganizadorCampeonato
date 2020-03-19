import { Campeonato } from "../../modelo/Campeonato";
import { Router } from "@angular/router";



export class LojaCarrinhoCompras {
  public campeonato: Campeonato;
  private router: Router ;


  public participar(campeonato: Campeonato) {
    
    
      this.campeonato = campeonato;


    sessionStorage.setItem("campeonatoStorage", JSON.stringify(this.campeonato));

  }

  public obterCampeonato(): Campeonato{
    var campeonatoLocalStorage = sessionStorage.getItem("campeonatoStorage");

    if (campeonatoLocalStorage) {
      return JSON.parse(campeonatoLocalStorage)
    }
    else {
      this.router.navigate(['/loja-pesquisa']);
    }


  }

  public removerCampeonato(campeonato: Campeonato) {
   
  }
}
