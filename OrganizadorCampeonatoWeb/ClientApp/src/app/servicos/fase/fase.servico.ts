import { Injectable, Inject, OnInit } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { getBaseUrl } from "../../../main";
import { Fase } from "../../modelo/Fase";
import { Campeonato } from "../../modelo/Campeonato";

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


  public deletar(fase: Fase): Observable<Campeonato[]> {

    return this.http.post<Campeonato[]>(this._baseUrl + "api/Fase/deletar", JSON.stringify(fase), { headers: this.headers });
  }

}
