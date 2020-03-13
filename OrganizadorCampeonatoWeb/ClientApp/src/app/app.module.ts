import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import {TruncateModule } from 'ng2-truncate';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';

import { CampeonatoComponent } from './campeonato/campeonato.component';
import { LoginComponent } from './usuario/login/login.component';
import { GuardaRotas } from './autorizacao/guardar.rotas';
import { UsuarioServico } from './servicos/usuario/usuario.servico';
import { CadastroUsuarioComponent } from './usuario/cadastro/cadastro.usuario.component';
import { CampeonatoServico } from './servicos/campeonato/campeonato.servico';
import { PesquisaCampeonatoComponent } from './campeonato/pesquisa/pesquisa.campeonato.component';
import { LojaPesquisaComponent } from './loja/pesquisa/loja.pesquisa.component';
import { LojaCampeonatoComponent } from './loja/campeonato/loja.campeonato.component';
import { LojaEfetivarComponent } from './loja/efetivar/loja.efetivar.component';
import { FaseComponent } from './fase/fase.component';
import { FaseServico } from './servicos/fase/fase.servico';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,

    CampeonatoComponent,
    LoginComponent,
    CadastroUsuarioComponent,
    PesquisaCampeonatoComponent,
    LojaPesquisaComponent,
    LojaCampeonatoComponent,
    LojaEfetivarComponent,
    FaseComponent,
    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    TruncateModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },

      { path: 'campeonato', component: CampeonatoComponent },
      { path: 'entrar', component: LoginComponent },
      { path: 'novo-usuario', component: CadastroUsuarioComponent },
      { path: 'pesquisar-campeonato', component: PesquisaCampeonatoComponent },

      { path: 'loja-campeonato', component: LojaCampeonatoComponent }, 
      { path: 'loja-efetivar', component: LojaEfetivarComponent },
      {path: 'fase', component: FaseComponent}

    ])
  ],
  providers: [UsuarioServico, CampeonatoServico, FaseServico],
  bootstrap: [AppComponent]
})
export class AppModule { }

//{ path: 'campeonato', component: CampeonatoComponent, canActivate: [GuardaRotas] },
