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

    constructor(private campeonatoServico: CampeonatoServico) {

    }


    ngOnInit(): void {
        this.campeonato = new Campeonato();;
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
