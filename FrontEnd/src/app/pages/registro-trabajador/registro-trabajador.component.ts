import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import { TrabajadorModel } from '../models/trabajador-model.model';
import { EstadoModel } from '../models/estado-model';

@Component({
  selector: 'app-registro-trabajador',
  templateUrl: './registro-trabajador.component.html',
  styleUrls: ['./registro-trabajador.component.css']
})
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
  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
  }

  sendTrabajador():void{
    let url = "https://localhost:44374/api/Usuario";
    this.http.post<any>(url,this.nuevoTrabajador).subscribe(
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
