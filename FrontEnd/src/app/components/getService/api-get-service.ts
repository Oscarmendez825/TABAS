import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import { HistorialTrabajadoresComponent } from 'src/app/pages/historialTrabajadores/historial-trabajadores/historial-trabajadores.component';
import { TrabajadorModel } from 'src/app/pages/models/trabajador-model.model';
import { VueloModel } from 'src/app/pages/models/vuelo-model';
import { BagCartModel } from 'src/app/pages/models/bag-cart-model';
import { MaletaModel } from 'src/app/pages/models/maleta-model';
import { ReporteModel } from 'src/app/pages/models/reporte-model';


@Injectable({
    providedIn: 'root'
})
/**
 * @description Clase utilizada para comunicarse con el API, encargada de los Get
 */
export class ApiGetService {
    private baseUrl = "https://localhost:44381/api";
    private getTrabajadoresHistorial = `${this.baseUrl}\\Usuario/Trabajadores`
    private getVueloG = `${this.baseUrl}\\Vuelo/Vuelos`
    private getBagCartG = `${this.baseUrl}\\BagCart/Bagcarts`
    private getMaletaG = `${this.baseUrl}\\Maleta/Maletas`
    private getReporteG = `${this.baseUrl}\\Reporte`

    /**
     * @description Método constructor
     * @param http 
     */
    constructor(private http: HttpClient) {

    }

    /**
     * @description Método para solicitar a todos los trabajadores
     * @returns TrabajadorModel[]
     */
    getTrabHist():Observable<TrabajadorModel[]>{
        return this.http.get<TrabajadorModel[]>(this.getTrabajadoresHistorial);
    }
    /**
     * @description Método para solicitar a todos los vuelos
     * @returns VueloModel[]
     */
    getVuelos():Observable<VueloModel[]>{
        return this.http.get<VueloModel[]>(this.getVueloG);
    }
    /**
     * @description Método para solicitar a todos los BagCarts
     * @returns BagCartModel[]
     */
    getBC():Observable<BagCartModel[]>{
        return this.http.get<BagCartModel[]>(this.getBagCartG);
    }
    /**
     * @description Método para solicitar a todas las maletas
     * @returns MaletaModel[]
     */
    getMaletas():Observable<MaletaModel[]>{
        return this.http.get<MaletaModel[]>(this.getMaletaG);
    }
    /**
     * @description Método para solicitar a todos los reportes
     * @returns ReporteModel[]
     */
    getReporte():Observable<ReporteModel[]>{
        return this.http.get<ReporteModel[]>(this.getReporteG);
    }

}
