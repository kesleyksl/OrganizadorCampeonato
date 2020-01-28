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

    constructor(private campeonatoServico: CampeonatoServico) {

    }


    ngOnInit(): void {
        this.campeonato = new Campeonato();
    }

    public inputChange(files: FileList) {
        this.arquivoSelecionado = files.item(0);
        this.campeonatoServico.enviarArquivo(this.arquivoSelecionado)
            .subscribe(
                retorno => {
                    console.log(retorno);
                },
                e => {
                    console.log(e.error);
                }
            );
        
    }

    public cadastrar() {
        this.campeonatoServico
            .cadastrar(this.campeonato)
            .subscribe(
                campeonatoJson => {
                    console.log(campeonatoJson);

                },
                e => {
                    console.log(e.error)
                }
            );
    }


}
