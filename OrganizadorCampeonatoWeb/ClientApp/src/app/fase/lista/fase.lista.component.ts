import { Component, OnInit } from "@angular/core"
import { Fase } from "../../modelo/Fase"
import { FaseServico } from "../../servicos/fase/fase.servico";
import { Router } from "@angular/router";
import { Campeonato } from "../../modelo/Campeonato";
@Component({
  selector: "lista-fases",
  templateUrl: "./fase.lista.component.html",
  styleUrls: ["./fase.lista.component.css"]

})

export class ListaFases implements OnInit {
  public fases: Fase[];
  public campeonato: Campeonato;
  ngOnInit(): void {

  }

  constructor(private faseServico: FaseServico, private router: Router) {
    var campeonatoSession = sessionStorage.getItem("campeonatoStorage");
    if (campeonatoSession) {
      this.campeonato = JSON.parse(campeonatoSession);

      this.faseServico.listarTodas(this.campeonato).subscribe(
        fases => {
          this.fases = fases;
        },
        e => {
          console.log(e.error);
        }
      );
    }

  }

}
