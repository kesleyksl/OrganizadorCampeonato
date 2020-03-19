import { Component, OnInit } from "@angular/core"
import { CampeonatoServico } from "../../servicos/campeonato/campeonato.servico";
import { Campeonato } from "../../modelo/Campeonato";
import { Router } from "@angular/router";

@Component({
  selector: "app-loja",
  templateUrl: "./loja.pesquisa.component.html",
  styleUrls: ["./loja.pesquisa.component.css"]
})

export class LojaPesquisaComponent implements OnInit {

  public campeonatos: Campeonato[];
  ngOnInit(): void {
       
    }

  constructor(private campeonatoServico: CampeonatoServico, private router: Router) {

    this.campeonatoServico.obterTodosCampeonatos().subscribe(
      campeonatos => {
        this.campeonatos = campeonatos
      },
      e => {
        console.log(e.error);
      }
    )
  }

  public participar(campeonato: Campeonato) {
    
    sessionStorage.setItem("campeonatoStorage", JSON.stringify(campeonato));
    this.router.navigate(['/loja-efetivar']);

  }
}
