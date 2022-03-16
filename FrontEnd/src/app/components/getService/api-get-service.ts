import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import { HistorialTrabajadoresComponent } from 'src/app/pages/historialTrabajadores/historial-trabajadores/historial-trabajadores.component';
import { TrabajadorModel } from 'src/app/pages/models/trabajador-model.model';
import { VueloModel } from 'src/app/pages/models/vuelo-model';
import { BagCartModel } from 'src/app/pages/models/bag-cart-model';


@Injectable({
    providedIn: 'root'
})
export class ApiGetService {
    private baseUrl = "https://localhost:44324/api";
    private getTrabajadoresHistorial = `${this.baseUrl}\\Usuario/Trabajadores`
    private getVuelo = `${this.baseUrl}\\Vuelo/Vuelos`
    private getBagCart = `${this.baseUrl}\\BagCart/Bagcarts`

    constructor(private http: HttpClient) {

    }

    getTrabHist():Observable<TrabajadorModel[]>{
        return this.http.get<TrabajadorModel[]>(this.getTrabajadoresHistorial);
    }

    getVuelos():Observable<VueloModel[]>{
        return this.http.get<VueloModel[]>(this.getVuelo);
    }
    getBC():Observable<BagCartModel[]>{
        return this.http.get<BagCartModel[]>(this.getBagCart);
    }
}
