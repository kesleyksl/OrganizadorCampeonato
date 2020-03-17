import { Component, OnInit } from "@angular/core"
import { Campeonato } from "../modelo/Campeonato";
import { CampeonatoServico } from "../servicos/campeonato/campeonato.servico";
import { Router } from "@angular/router";
import { UsuarioServico } from "../servicos/usuario/usuario.servico";

@Component({
  selector: "app-campeonato",
  templateUrl: "./campeonato.component.html",
  styleUrls: ["./campeonato.componet.css"],
})

export class CampeonatoComponent implements OnInit {

  public campeonato: Campeonato;
  public arquivoSelecionado: File;
  public ativar_spinner: boolean;
  public mensagem: string;

  constructor(private campeonatoServico: CampeonatoServico, private router: Router, private usuarioServico: UsuarioServico) {

  }


  ngOnInit(): void {
    var campeonatoSessao = sessionStorage.getItem('campeonatoSessao');
    if (campeonatoSessao) {
      this.campeonato = JSON.parse(campeonatoSessao);
    }
    else {
      this.campeonato = new Campeonato();
    }

 
  }

  public inputChange(files: FileList) {
    this.arquivoSelecionado = files.item(0);
    this.ativarEspera();
    this.campeonatoServico.enviarArquivo(this.arquivoSelecionado)
      .subscribe(
        nomeArquivo => {
          this.campeonato.nomeArquivo = nomeArquivo;
     
          console.log(nomeArquivo);
          this.desativarEspera();

         
        },
        e => {
          console.log(e.error);
          this.desativarEspera();

        }
    );

  

  }

  public editarFase() {
    sessionStorage.setItem("campeonatoCriado", JSON.stringify(this.campeonato));
    this.router.navigate(['/fase']);;
  }

  public cadastrar() {
    this.ativarEspera();
    this.campeonato.usuarioId = this.usuarioServico.usuario.id;
    this.campeonatoServico
      .cadastrar(this.campeonato)
      .subscribe(
        campeonatoJson => {
          sessionStorage.setItem("campeonatoCriado", JSON.stringify( campeonatoJson))
          this.desativarEspera();
          this.router.navigate(['/fase']);
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


}
