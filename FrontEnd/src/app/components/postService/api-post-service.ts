import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import { TrabajadorModel } from 'src/app/pages/models/trabajador-model.model';
import { MaletaModel } from 'src/app/pages/models/maleta-model';
import { VueloModel } from 'src/app/pages/models/vuelo-model';


@Injectable({
    providedIn: 'root'
})
export class ApiPostService {
    private baseUrl = "https://localhost:44324/api";
    private regTrab = `${this.baseUrl}\\Usuario`
    private regMal = `${this.baseUrl}\\Maleta`
    private iniciarSesion = `${this.baseUrl}\\Usuario/IniciarSesion`
    private bagCart = `${this.baseUrl}\\Vuelo/AsignarBCVuelo`


    constructor(private http: HttpClient) {

    }

    registrarTrab(trabajador: TrabajadorModel):Observable<any>{
        return this.http.post<any>(this.regTrab, trabajador);
    }

    registrarMaleta(maleta: MaletaModel):Observable<any>{
        return this.http.post<any>(this.regMal, maleta);
    }

    IniciarSesion(trabajador: TrabajadorModel):Observable<any>{
        return this.http.post<any>(this.iniciarSesion, trabajador);
    }
    asignarBagCart(vuelo: VueloModel):Observable<any>{
        return this.http.post<any>(this.bagCart, vuelo);
    }

}
