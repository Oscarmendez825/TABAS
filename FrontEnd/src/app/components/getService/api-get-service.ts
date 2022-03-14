import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import { HistorialTrabajadoresComponent } from 'src/app/pages/historialTrabajadores/historial-trabajadores/historial-trabajadores.component';
import { TrabajadorModel } from 'src/app/pages/models/trabajador-model.model';


@Injectable({
    providedIn: 'root'
})
export class ApiGetService {
    private baseUrl = "https://localhost:44374/api/Usuario";
    private getTrabajadoresHistorial = `${this.baseUrl}\\Trabajadores`

    constructor(private http: HttpClient) {

    }

    getTrabHist():Observable<TrabajadorModel[]>{
        return this.http.get<TrabajadorModel[]>(this.getTrabajadoresHistorial);
    }
}
