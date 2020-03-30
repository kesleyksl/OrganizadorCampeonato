import { Component, OnInit } from "@angular/core"
import { Competidor } from "../../modelo/Competidor"
import { Fase } from "../../modelo/Fase";
import { FaseServico } from "../../servicos/fase/fase.servico";
import { Campeonato } from "../../modelo/Campeonato";
import { UsuarioServico } from "../../servicos/usuario/usuario.servico";
import { CampeonatoServico } from "../../servicos/campeonato/campeonato.servico";

@Component({
  selector: "campeonato-competidores",
  templateUrl: "./competidores.component.html",
  styleUrls: ["./competidores.component.css"]

})

export class CompetidoresComponent implements OnInit {

  public competidores: Competidor[];
  public campeonato: Campeonato;


  constructor(private usuarioServico: UsuarioServico, private campeonatoServico: CampeonatoServico) {

  }

  ngOnInit(): void {


    var campeonatoSession = sessionStorage.getItem("campeonatoStorage");

    if (campeonatoSession) {


      this.campeonato = JSON.parse(campeonatoSession);
      this.campeonatoServico.getCompetidoresStatus(this.campeonato.id, 2).subscribe(
        competidores => {
          this.competidores = competidores;
        },
        e => {
          console.log(e.error);
        }
      )
     
    }

  }

  public selecionaFase(faseId, competidorId) {
    var posicao = this.competidores.findIndex(c => c.id == competidorId);

    this.competidores[posicao].faseId = faseId;

  }

  public confirmarInscricao(competidor: Competidor, status: number) {
  
    if (status === 3) {
      var retorno = confirm(`Deseja realmente a inscrição de ${competidor.usuario.nome}`);
    }
    if (retorno === true || status !== 3) {
      competidor.statusInscricaoId = status;

      this.usuarioServico.confirmarInscricao(competidor).subscribe(


        sucess => {
   

          this.ngOnInit();
        },
        e => {
          alert('Algo inesperado aconteceu. Tente novamente');
        }

      );
    }
  }
}
