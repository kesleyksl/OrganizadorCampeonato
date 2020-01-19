import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';

import { CampeonatoComponent } from './campeonato/campeonato.component';
import { LoginComponent } from './usuario/login/login.component';
import { GuardaRotas } from './autorizacao/guardar.rotas';
import { UsuarioServico } from './servicos/usuario/usuario.servico';
import { CadastroUsuarioComponent } from './usuario/cadastro/cadastro.usuario.component';
import { CampeonatoServico } from './servicos/campeonato/campeonato.servico';


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,

        CampeonatoComponent,
        LoginComponent,
        CadastroUsuarioComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', component: HomeComponent, pathMatch: 'full' },

            { path: 'campeonato', component: CampeonatoComponent},
            { path: 'entrar', component: LoginComponent },
            { path: 'novo-usuario', component: CadastroUsuarioComponent }
        ])
    ],
    providers: [UsuarioServico, CampeonatoServico],
    bootstrap: [AppComponent]
})
export class AppModule { }

//{ path: 'campeonato', component: CampeonatoComponent, canActivate: [GuardaRotas] },
