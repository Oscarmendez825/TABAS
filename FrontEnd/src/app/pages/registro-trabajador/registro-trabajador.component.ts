import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import { TrabajadorModel } from '../models/trabajador-model.model';
import { EstadoModel } from '../models/estado-model';
import { ApiPostService } from 'src/app/components/postService/api-post-service';

@Component({
  selector: 'app-registro-trabajador',
  templateUrl: './registro-trabajador.component.html',
  styleUrls: ['./registro-trabajador.component.css']
})
/**
 * @description: Clase utilizada para todo el form del registro de un nuevo trabajador
 */
export class RegistroTrabajadorComponent implements OnInit {

  nuevoTrabajador: TrabajadorModel =
  {
    Nombre: '',
    Apellido: '',
    Cedula: 0,
    contrasena: '',
    rol: ''
  }
  estadoRes: EstadoModel = {
    estado:""
  }
  /**
   * @description Método constructor
   * @param http 
   * @param router 
   * @param apiService 
   */
  constructor(private http: HttpClient, private router: Router, private apiService: ApiPostService) { }

  ngOnInit(): void {
  }

  /**
   * @description Método para enviar la información del trabajador a la DB
   */
  sendTrabajador():void{
    this.apiService.registrarTrab(this.nuevoTrabajador).subscribe(
      res =>{
        this.estadoRes = res;
        if(this.estadoRes.estado == "OK"){
          location.reload();
        }else{
          alert("Hubo un problema al realizar su registro");
        }    
      }
    );
}
}
