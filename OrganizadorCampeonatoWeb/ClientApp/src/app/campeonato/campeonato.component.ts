import { Component, OnInit } from "@angular/core"
import { Campeonato } from "../modelo/Campeonato";
import { CampeonatoServico } from "../servicos/campeonato/campeonato.servico";

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

  constructor(private campeonatoServico: CampeonatoServico) {

  }


  ngOnInit(): void {
    this.campeonato = new Campeonato();
  }

  public inputChange(files: FileList) {
    this.arquivoSelecionado = files.item(0);
    this.ativarEspera();
    this.campeonatoServico.enviarArquivo(this.arquivoSelecionado)
      .subscribe(
        nomeArquivo => {
          this.campeonato.nomeArquivo = nomeArquivo;
          alert(this.campeonato.nomeArquivo);
          console.log(nomeArquivo);
          this.desativarEspera();
         
        },
        e => {
          console.log(e.error);
          this.desativarEspera();

        }
    );

  

  }

  public cadastrar() {
    this.ativarEspera();
    this.campeonatoServico
      .cadastrar(this.campeonato)
      .subscribe(
        campeonatoJson => {
          console.log(campeonatoJson);
          this.desativarEspera();
     
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
