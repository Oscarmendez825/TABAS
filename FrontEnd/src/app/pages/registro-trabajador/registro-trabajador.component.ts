import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";

@Component({
  selector: 'app-registro-trabajador',
  templateUrl: './registro-trabajador.component.html',
  styleUrls: ['./registro-trabajador.component.css']
})
export class RegistroTrabajadorComponent implements OnInit {

  nuevoTrabajador: Trabajador =
  {
    Nombre: '',
    Apellido: '',
    Cedula: 0,
    Contrasena: '',
    rol: ''
  }
  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
  }

  sendTrabajador():void{
    let url = "http://localhost:32967/api/Usuario";
    this.http.post(url,this.nuevoTrabajador).subscribe(
      res =>{
        location.reload();

      },
      error => {
        alert("An error has occurred while sending data");
      }
    );
}
}


export interface Trabajador{
  Nombre:string;
  Apellido:string;
  Cedula:number;
  Contrasena:string;
  rol: string;
}