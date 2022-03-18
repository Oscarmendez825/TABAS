import { Component, OnInit } from '@angular/core';
import { TrabajadorModel } from '../../models/trabajador-model.model';
import { ApiGetService } from 'src/app/components/getService/api-get-service';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-historial-trabajadores',
  templateUrl: './historial-trabajadores.component.html',
  styleUrls: ['./historial-trabajadores.component.css']
})

/**
 * @description: Clase utilizada para todo el form de la lista de los trabajadores
 */
export class HistorialTrabajadoresComponent implements OnInit {

  trabajadores: TrabajadorModel[]=[];
  /**
   * @description: Método constructor
   * @param apiService 
   */
  constructor(private apiService:ApiGetService) { }
  ngOnInit(): void {
    this.getHistorial();
  }
  /**
   * @description: Método para solicitar el historial de los trabajadores en planilla
   */
  public getHistorial(){
    this.apiService.getTrabHist().subscribe(
      res => {
        this.trabajadores = res;
      },
      err => {
        alert("Ha habido un error")
      }

    );
  }
}
