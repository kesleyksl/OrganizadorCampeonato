import { Component, OnInit } from '@angular/core'
import { CampeonatoServico } from '../../servicos/campeonato/campeonato.servico';
import { Campeonato } from '../../modelo/Campeonato';
import { Router } from '@angular/router';
import { LojaCarrinhoCompras } from '../carrinho/loja.carrinho.component';


@Component({
  selector: 'loja-app-campeonato',
  templateUrl: './loja.campeonato.component.html',
  styleUrls: ['./loja.campeonato.component.css']
})

export class LojaCampeonatoComponent implements OnInit {
  public campeonato: Campeonato;

  public carrinhoCompras: LojaCarrinhoCompras;

  ngOnInit(): void {
    this.carrinhoCompras = new LojaCarrinhoCompras();
    var campeonatoDetalhe = sessionStorage.getItem("campeonatoDetalhe");

    if (campeonatoDetalhe) {
      this.campeonato = JSON.parse(campeonatoDetalhe);
    }
  }

  constructor(private campeonatoServico: CampeonatoServico, private router: Router) {

  }

  public comprar() {
    this.carrinhoCompras.adicionar(this.campeonato)

    this.router.navigate(['/loja-efetivar']);
  }
}
