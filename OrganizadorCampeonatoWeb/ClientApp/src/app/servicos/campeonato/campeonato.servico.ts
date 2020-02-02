import { Injectable, Inject, OnInit } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { getBaseUrl } from "../../../main";
import { Campeonato } from "../../modelo/Campeonato";

@Injectable({
    providedIn: "root"
})
export class CampeonatoServico implements OnInit {
   

    private _baseUrl: string;
    public campeonatos: Campeonato[];

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

        this._baseUrl = baseUrl;

    }

    ngOnInit(): void {
        this.campeonatos = [];
    }

    get headers(): HttpHeaders {
        return new HttpHeaders().set('content-type', 'application/json');
    }

    public cadastrar(campeonato: Campeonato): Observable<Campeonato> {



        return this.http.post<Campeonato>(this._baseUrl + "api/campeonato", JSON.stringify(campeonato), { headers: this.headers });
    }

    public salvar(campeonato: Campeonato): Observable<Campeonato> {

        return this.http.post<Campeonato>(this._baseUrl + "api/campeonato/salvar", JSON.stringify(campeonato), { headers: this.headers });
    }

    public deletar(campeonato: Campeonato): Observable<Campeonato> {

        return this.http.post<Campeonato>(this._baseUrl + "api/campeonato/deletar", JSON.stringify(campeonato), { headers: this.headers });
    }
    public obterTodosCampeonatos(): Observable<Campeonato[]> {

        return this.http.get<Campeonato[]>(this._baseUrl + "api/campeonato/obterCampeonatos");
    }
    public obterCampeonatos(produtoId: number): Observable<Campeonato> {


        return this.http.get<Campeonato>(this._baseUrl + "api/campeonato/obterCampeonatos");
    }

    public enviarArquivo(arquivoSelecionado: File): Observable<string> {
        const formData: FormData = new FormData();
        formData.append("arquivoEnviado", arquivoSelecionado, arquivoSelecionado.name);
        return this.http.post<string>(this._baseUrl + "api/Campeonato/EnviarArquivo", formData);
    }

}
