import { Component, OnInit } from "@angular/core"
import { Campeonato } from "../../modelo/Campeonato";
import { Fase } from "../../modelo/Fase";
import { Competidor } from "../../modelo/Competidor";
import { FaseServico } from "../../servicos/fase/fase.servico";
import { CampeonatoServico } from "../../servicos/campeonato/campeonato.servico";
import { error } from "protractor";

@Component({
  selector: "app-faseCompetidores",
  templateUrl: "./fase.competidores.component.html",
  styleUrls: ["./fase.competidores.component.css"]
})

export class FaseCompetidoresComponent implements OnInit{
  public campeonato: Campeonato;
  public fase: Fase;
  public competidores: Competidor[];
  public competidoresFase: Competidor[];
  
  
  constructor(private faseServico: FaseServico, private campeonatoServico: CampeonatoServico) {

     


  }
  ngOnInit(): void {
    var campeonato = sessionStorage.getItem("campeonato");
    var fase = sessionStorage.getItem("fase");
    if (fase) {
      this.fase = JSON.parse(fase);
    };

    if (campeonato) {
      this.campeonato = JSON.parse(campeonato);
      this.faseServico.getCompetidoresNaoCadastradoNaFase(this.campeonato.id, this.fase.id).subscribe(
        competidores => {

          this.competidores = competidores;




        },
        e => {
          console.log(e.error);
        }

      );
      this.faseServico.getCompetidoresFase(this.fase.id).subscribe(
        competidores => {
          this.competidoresFase = competidores;


        },
        e => {
          console.log(e.error);
        }

      )


    }

  }

  public cadastrarCompetidor(competidorId: number) {
    this.faseServico.cadastrarCompetidor(this.fase.id, competidorId).subscribe(
      success => {
        this.ngOnInit();
      },
      e => {
        console.log(e.error);
      }
    );


  }



  public remover(competidorId: number, competidorFaseId: number) {
    
    this.faseServico.deletarCompetidor(competidorId, this.fase.id, competidorFaseId).subscribe(
      success => {
        this.ngOnInit();
      },
      ex => {
        console.log(ex.error);
      }
    );
  }
}
