import { Component, OnInit } from "@angular/core"
import { Competidor } from "../../modelo/Competidor"

@Component({
  selector: "campeonato-competidores",
  templateUrl: "./competidores.component.html",
  styleUrls: ["./competidores.component.css"]

})

export class CompetidoresComponent implements OnInit {

  public competidores: Competidor[];
 


  ngOnInit(): void {
    var competidoresSessao = sessionStorage.getItem('competidores');
    
    if (competidoresSessao) {
      
      this.competidores = JSON.parse(competidoresSessao);
      console.log(this.competidores);
    }
    else {
      this.competidores = [];
    }

  }

  constructor() {

  }
}
