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
    private baseUrl = "https://localhost:44381/api";
    private regTrab = `${this.baseUrl}\\Usuario`
    private regMal = `${this.baseUrl}\\Maleta`
    private iniciarSesion = `${this.baseUrl}\\Usuario/IniciarSesion`
    private bagCart = `${this.baseUrl}\\Vuelo/AsignarBCVuelo`


    /**
     * Método constructor
     * @param http 
     */
    constructor(private http: HttpClient) {

    }

    /**
     * @description Método utilizado para registrar un trabajador
     * @param trabajador 
     * @returns EstadoModel Object
     */
    registrarTrab(trabajador: TrabajadorModel):Observable<any>{
        return this.http.post<any>(this.regTrab, trabajador);
    }
    /**
     * @description Método utilizado para registrar una maleta
     * @param maleta 
     * @returns EstadoModel Object
     */
    registrarMaleta(maleta: MaletaModel):Observable<any>{
        return this.http.post<any>(this.regMal, maleta);
    }
    /**
     * @description Método utilizado para iniciar sesión
     * @param trabajador 
     * @returns EstadoModel Object
     */
    IniciarSesion(trabajador: TrabajadorModel):Observable<any>{
        return this.http.post<any>(this.iniciarSesion, trabajador);
    }
    /**
     * @description Método utilizado para asignar un BC a un vuelo
     * @param vuelo 
     * @returns EstadoModel Object
     */
    asignarBagCart(vuelo: VueloModel):Observable<any>{
        return this.http.post<any>(this.bagCart, vuelo);
    }

}
