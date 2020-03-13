import { Component, OnInit } from "@angular/core"
import { Campeonato } from "../../modelo/Campeonato";
import { CampeonatoServico } from "../../servicos/campeonato/campeonato.servico";
import { Usuario } from "../../modelo/usuario";
import { Router } from "@angular/router";
@Component({

  selector: "pesquisa-campeonato",
  templateUrl:"./pesquisa.campeonato.component.html",
  styleUrls:["./pesquisa.campeonato.component.css"]

})

export class PesquisaCampeonatoComponent implements OnInit{

  public campeonatos: Campeonato[];



  ngOnInit(): void {
        
   }

  constructor(private campeonatoServico: CampeonatoServico, private router: Router) {
    this.campeonatoServico.obterTodosCampeonatos()
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
}
