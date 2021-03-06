import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { getBaseUrl } from "../../../main";
import { Usuario } from "../../modelo/usuario";
import { Competidor } from "../../modelo/Competidor";


@Injectable({
    providedIn: 'root'
})



export class UsuarioServico {

    private baseURL: string;
    private _usuario: Usuario;


    set usuario(usuario: Usuario) {
        sessionStorage.setItem("usuario-autenticado", JSON.stringify(usuario));
        this._usuario = usuario;
        //sessionStorage.setItem("email-usuario", usuarioRetorno.email);
    }
    get usuario(): Usuario {
        let usuario_json = sessionStorage.getItem("usuario-autenticado");
        this._usuario = JSON.parse(usuario_json);
        return this._usuario;
    }

    public usuario_autenticado(): boolean {
        return this._usuario != null && this._usuario.email != '' && this._usuario.senha != "";
    }
    public limpar_sessao() {
        sessionStorage.setItem("usuario-autenticado", "");
        this._usuario = null;
    }


    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseURL = baseUrl;
    }

    public verificarUsuario(usuario: Usuario): Observable<Usuario> {
        const headers = new HttpHeaders().set('content-type', 'application/json');

        var body = {
            email: usuario.email,
            senha: usuario.senha
        }

        return this.http.post<Usuario>(this.baseURL + "api/Usuario/VerificarUsuario", body, { headers });
  }

  public confirmarInscricao(competidor: Competidor): Observable<Competidor> {
    const headers = new HttpHeaders().set('content-type', 'application/json');



    return this.http.post<Competidor>(this.baseURL + "api/Usuario/ConfirmarInscricao", competidor, { headers });
  }

    public cadastrarUsuario(usuario: Usuario): Observable<Usuario> {
        const headers = new HttpHeaders().set('content-type', 'application/json');

        var body = {
            email: usuario.email,
            senha: usuario.senha,
            nome: usuario.nome,
            sexo: usuario.sexo,
            telefone: usuario.telefone

        }

        return this.http.post<Usuario>(this.baseURL + "api/usuario", body, { headers });


  }

  public competir(competidor: Competidor): Observable<Competidor> {
    const headers = new HttpHeaders().set('content-type', 'application/json');

    return this.http.post<Competidor>(this.baseURL + "api/usuario/competir", JSON.stringify(competidor), { headers });

  }



}
