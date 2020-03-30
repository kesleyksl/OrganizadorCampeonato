import { Injectable, Inject, OnInit } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { getBaseUrl } from "../../../main";
import { Fase } from "../../modelo/Fase";
import { Campeonato } from "../../modelo/Campeonato";
import { Competidor } from "../../modelo/Competidor";

@Injectable({
  providedIn: "root"
})

export class FaseServico implements OnInit {
   
  private _baseUrl: string;
  public fases: Fase[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl


  }

  ngOnInit(): void {
    this.fases = [];
  }

  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json');
  }

  public cadastrar(fase: Fase): Observable<Fase> {



    return this.http.post<Fase>(this._baseUrl + "api/Fase", JSON.stringify(fase), { headers: this.headers });
  }

  public listarTodas(campeonato: Campeonato): Observable<Fase[]> {
    return this.http.post<Fase[]>(this._baseUrl + "api/Fase/Todas", JSON.stringify(campeonato), { headers: this.headers });
  }

  public cadastrarCompetidor(faseId: number, competidorId: number): Observable<Competidor> {
  var  body = {
      faseId : faseId,
      competidorId : competidorId
    }
    return this.http.post<Competidor>(this._baseUrl + "api/Fase/CadastrarCompetidor", JSON.stringify(body), { headers: this.headers });
  }


  public getCompetidoresFase(faseId: number): Observable<Competidor[]> {
    return this.http.post<Competidor[]>(this._baseUrl + "api/Fase/GetCompetidoresFase", faseId, { headers: this.headers });
  }
  public getCompetidoresNaoCadastradoNaFase(campeonatoId: number, faseId: number): Observable<Competidor[]> {
    var body = {
      faseId: faseId,
      campeonatoId: campeonatoId
    }
    return this.http.post<Competidor[]>(this._baseUrl + "api/Fase/GetCompetidoresNaoCadastradoNaFase", JSON.stringify(body), { headers: this.headers });
  } 
  public deletar(fase: Fase): Observable<Campeonato[]> {

    return this.http.post<Campeonato[]>(this._baseUrl + "api/Fase/deletar", JSON.stringify(fase), { headers: this.headers });
  }
  public deletarCompetidor(competidorId: number, faseId: number, usuarioFaseId: number): Observable<Competidor> {
    let body = {
      competidorId: competidorId,
      faseId: faseId,
      usuarioFaseId: usuarioFaseId
    }
    return this.http.post<Competidor>(this._baseUrl + "api/Fase/DeletarCompetidor", JSON.stringify(body), { headers: this.headers });
  }

}
