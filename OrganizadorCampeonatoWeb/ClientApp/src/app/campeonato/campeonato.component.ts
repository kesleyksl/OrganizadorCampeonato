import { Component } from "@angular/core"

@Component({
    selector: "aoo-campeonato",
    template : "<html><body>{{obterNome()}}</body></html>"
})

export class CampeonatoComponent{
    public nome: string;



    public obterNome(): string {
        return "Adrenalina";
    }

}
