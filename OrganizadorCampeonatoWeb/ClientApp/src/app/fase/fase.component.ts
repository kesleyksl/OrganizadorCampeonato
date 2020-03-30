import { Component, OnInit } from '@angular/core'
import { Campeonato } from '../modelo/Campeonato'
import { Router } from '@angular/router';
import { Fase } from '../modelo/Fase';
import { FaseServico } from '../servicos/fase/fase.servico';



enum TipoFase {
  JackAndJill = 1 ,
  Improviso,
  Coreografia
}


@Component({
  selector: "app-fase",
  templateUrl: "./fase.component.html",
  styleUrls: ["./fase.component.css"],
})

export class FaseComponent implements OnInit {
  public campeonato = new Campeonato();
  public fase: Fase;
  public ativar_spinner: boolean;
  public options= [];
  public tipoFase = TipoFase;
  public mensagem: string;
  public fases: Fase[];


  ngOnInit(): void {
   
    this.fase = new Fase();

    this.fase.data = new Date().toJSON().slice(0, 10).replace(/-/g, '-');
    this.options = Object.keys(this.tipoFase);
    this.options = this.options.slice(this.options.length / 2);
    var campeonatoCriado = sessionStorage.getItem("campeonatoCriado");

    sessionStorage.removeItem("campeonatoCriado");

    if (campeonatoCriado) {
      this.campeonato = JSON.parse(campeonatoCriado);

      this.fase.campeonatoId = this.campeonato.id;
      this.faseServico.listarTodas(this.campeonato).subscribe(
        fases => {
          
          this.fases = fases;
 
        },
        e => {
          console.log(e.error);
        });
    }
    else {
      this.router.navigate(['/campeonato'])
    }

    


  }

  constructor(private router: Router, private faseServico: FaseServico) {

  }

  

  public inputChange(i: any) {
    console.log(this.fase.tipoFaseId, i);
  }
  public cadastrar() {

  
      this.ativarEspera();
      this.faseServico
        .cadastrar(this.fase)
        .subscribe(
          campeonatoJson => {
            sessionStorage.setItem("campeonatoCriado", JSON.stringify(this.campeonato))
            this.desativarEspera();

            this.mensagem = null;

            this.ngOnInit();

          },
          e => {
            console.log(e.error);
            this.mensagem = e.error;

            this.desativarEspera();
          }

        );


  }
  public ativarEspera() {
    this.ativar_spinner = true;
  }
  public desativarEspera() {
    this.ativar_spinner = false;
  }

  public editarFase(fase: Fase) {
    sessionStorage.setItem('faseSessao', JSON.stringify(fase));
    //this.router.navigate(['/fase']);
    //location.reload();
    fase.data = fase.data.slice(0, 10);
    this.fase = fase;
   


  }



  public deletar(fase: Fase) {

    var retorno = confirm("Deseja realmente deletar a fase selecionada?");
    if (retorno === true) {
      this.faseServico.deletar(fase).subscribe(
        campeonatoJson => {
          sessionStorage.setItem("campeonatoCriado", JSON.stringify(campeonatoJson));

          this.ngOnInit();
        }, e => {
          console.log(e.errors);
        }
      );
    }
  }

  public competidoresFase(fase: Fase) {

    sessionStorage.setItem("campeonato", JSON.stringify(this.campeonato));
    sessionStorage.setItem("fase", JSON.stringify(fase));
    this.router.navigate(['/fase-competidores']);
  }

}
