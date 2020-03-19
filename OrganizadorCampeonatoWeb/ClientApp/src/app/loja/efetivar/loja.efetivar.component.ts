import {Component, OnInit } from '@angular/core'
import { LojaCarrinhoCompras } from '../carrinho/loja.carrinho.component'
import { Campeonato } from '../../modelo/Campeonato';
import { UsuarioServico } from '../../servicos/usuario/usuario.servico';
import { Competidor } from '../../modelo/Competidor';

@Component({
  selector: 'loja-efetivar',
    templateUrl: './loja.efetivar.component.html',
    styleUrls: ['./loja.efetivar.component.css']

})



export class LojaEfetivarComponent implements OnInit{
  public carrinhoCompras: LojaCarrinhoCompras;
  public campeonato: Campeonato;
  public competidor: Competidor;
  public error: Error;
  public success: string;

  constructor(private usuarioServico: UsuarioServico) {

  }
    ngOnInit(): void {
      this.carrinhoCompras = new LojaCarrinhoCompras();
      this.competidor = new Competidor();
      this.campeonato = this.carrinhoCompras.obterCampeonato();
  }

  public competir() {
    this.competidor.campeonatoId = this.campeonato.id;

    this.competidor.usuarioId = this.usuarioServico.usuario.id;
    this.usuarioServico.competir(this.competidor).subscribe(
      competidor => {
        
        this.success = "Inscrição realizada. Aguarde a confirmação";
        this.error = null;
      },
      e => {
        this.error = e.error;
        this.success = null;
      }
    )
  }


}
