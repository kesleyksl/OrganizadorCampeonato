import { Component, OnInit } from '@angular/core'
import { CampeonatoServico } from '../../servicos/campeonato/campeonato.servico';
import { Campeonato } from '../../modelo/Campeonato';


@Component({
  selector: 'loja-app-campeonato',
  templateUrl: './loja.campeonato.component.html',
  styleUrls: ['./loja.campeonato.component.css']
})

export class LojaCampeonatoComponent implements OnInit{
  public campeonato: Campeonato;



    ngOnInit(): void {
      var campeonatoDetalhe = sessionStorage.getItem("campeonatoDetalhe");

      if (campeonatoDetalhe) {
        this.campeonato = JSON.parse(campeonatoDetalhe);
      }
  }

  constructor(private campeonatoServico: CampeonatoServico) {

  }

}
