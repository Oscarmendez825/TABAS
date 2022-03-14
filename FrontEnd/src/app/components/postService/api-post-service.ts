import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import { TrabajadorModel } from 'src/app/pages/models/trabajador-model.model';


@Injectable({
    providedIn: 'root'
})
export class ApiPostService {
    private baseUrl = "https://localhost:44374/api/Usuario";
    

    constructor(private http: HttpClient) {

    }

    registrarTrab(trabajador: TrabajadorModel):Observable<any>{
        return this.http.post<any>(this.baseUrl, trabajador);
    }
}
