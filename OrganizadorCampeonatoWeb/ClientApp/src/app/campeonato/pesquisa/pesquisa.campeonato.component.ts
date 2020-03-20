import { Component, OnInit } from "@angular/core"
import { Campeonato } from "../../modelo/Campeonato";
import { CampeonatoServico } from "../../servicos/campeonato/campeonato.servico";
import { Usuario } from "../../modelo/usuario";
import { Router } from "@angular/router";
import { UsuarioServico } from "../../servicos/usuario/usuario.servico";
import { Competidor } from "../../modelo/Competidor";
@Component({

  selector: "pesquisa-campeonato",
  templateUrl:"./pesquisa.campeonato.component.html",
  styleUrls:["./pesquisa.campeonato.component.css"]

})

export class PesquisaCampeonatoComponent implements OnInit{

  public campeonatos: Campeonato[];
  public competidores: Competidor[];


  ngOnInit(): void {
        
   }

  constructor(private campeonatoServico: CampeonatoServico, private router: Router, private usuarioServico: UsuarioServico) {
    this.campeonatoServico.obterTodosCampeonatosUsuario(this.usuarioServico.usuario)
      .subscribe(
        campeonatos => {
          console.log(campeonatos);
          this.campeonatos = campeonatos;
        },
        e => {
          console.log(e.error);
        }

      )
  }

  public adicionarCampeonato() {
    sessionStorage.setItem("campeonatoSessao", "");
    this.router.navigate(['/campeonato']);
  }

  public deletarCampeonato(campeonato: Campeonato) {

    var retorno = confirm("Deseja realmente deletar o campeonato selecionado?");
    if (retorno === true) {
      this.campeonatoServico.deletar(campeonato).subscribe(
        campeonatos => {
          this.campeonatos = campeonatos;
        }, e => {
          console.log(e.errors);
        }
      );
    }
  }
  public editarFase(c: Campeonato) {
    sessionStorage.setItem("campeonatoCriado", JSON.stringify(c));
    this.router.navigate(['/fase']);;
  }
  public editarCampeonato(campeonato: Campeonato) {
    sessionStorage.setItem('campeonatoSessao', JSON.stringify(campeonato));
    this.router.navigate(['/campeonato']);
  }

  public gerenciarCampeonato(campeoantoId: number) {

    this.campeonatoServico.getCompetidores(campeoantoId).subscribe(
      competidores => {
        this.competidores = competidores;
        console.log(JSON.stringify(competidores));
        sessionStorage.setItem("competidores", JSON.stringify(this.competidores));
        this.router.navigate(['/campeonato-competidores']);
      },
      e => {
        console.log(e.error);
      }
    );
  }
}
