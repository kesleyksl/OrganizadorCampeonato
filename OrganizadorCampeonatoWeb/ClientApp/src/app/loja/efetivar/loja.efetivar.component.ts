import {Component, OnInit } from '@angular/core'
import { LojaCarrinhoCompras } from '../carrinho/loja.carrinho.component'
import { Campeonato } from '../../modelo/Campeonato';

@Component({
  selector: 'loja-efetivar',
    templateUrl: './loja.efetivar.component.html',
    styleUrls: ['./loja.efetivar.component.css']

})

export class LojaEfetivarComponent implements OnInit{
  public carrinhoCompras: LojaCarrinhoCompras;
  public campeonatos: Campeonato[];
    ngOnInit(): void {
      this.carrinhoCompras = new LojaCarrinhoCompras();
      this.campeonatos = this.carrinhoCompras.obterCampeonatos();
  }


}
