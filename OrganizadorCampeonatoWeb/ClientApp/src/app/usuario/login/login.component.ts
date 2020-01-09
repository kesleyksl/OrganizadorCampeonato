import { Component, OnInit } from "@angular/core";
import { Usuario } from "../../modelo/usuario";
import { Router, ActivatedRoute } from "@angular/router";
import { UsuarioServico } from "../../servicos/usuario/usuario.servico";


@Component({
    selector: 'app-login',
    templateUrl: "./login.component.html",
    styleUrls: ["./login.component.css"]
})
export class LoginComponent implements OnInit {
    
    public usuario;
    public returnUrl: string;
    public mensagem: string;
    public ativar_spinner: boolean;


    constructor(private router: Router, private activatedRouter: ActivatedRoute, private usuarioServico : UsuarioServico ) {
    }

    ngOnInit(): void {
        this.usuario = new Usuario();
        
        this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl'];

    }

    entrar() {
        this.ativar_spinner = true;
        this.usuarioServico.verificarUsuario(this.usuario).subscribe(
            usuario_json => {
               // var usuarioRetorno = data;
                //sessionStorage.setItem("usuario-autenticado", "1");
                //sessionStorage.setItem("email-usuario", usuarioRetorno.email);
                //alert(this.returnUrl);
                this.usuarioServico.usuario = usuario_json;
                if (this.returnUrl == null) {
                    this.router.navigate(["/"])
                } else {
                    this.router.navigate([this.returnUrl]);

                }


            },
            err => {
                console.log(err.error);
                this.ativar_spinner = false;
                this.mensagem = err.error;
                
            }

        );

        //if (this.usuario.email == 'teste@teste.com.br' && this.usuario.senha == '123456') {
        //    sessionStorage.setItem("usuario-autenticado", "1");
        //    this.router.navigate([this.returnUrl]);
        //}

    }

}

