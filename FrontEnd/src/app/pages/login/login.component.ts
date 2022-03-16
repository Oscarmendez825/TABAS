import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { EstadoModel } from '../models/estado-model';
import { TrabajadorModel } from '../models/trabajador-model.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  trabajadorLogIn: TrabajadorModel =
  {
    Nombre: '',
    Apellido: '',
    Cedula: 0,
    contrasena: '',
    rol: ''
  }

  constructor(private Auth:AuthService) { }

  ngOnInit(): void {}

  loginUser(event: { preventDefault: () => void; target: any; }){

    event.preventDefault();
    const target= event.target;
    const cedula= target.querySelector("#cedula").value;
    const password= target.querySelector("#password").value;

    this.trabajadorLogIn.Cedula = cedula;
    this.trabajadorLogIn.contrasena = password;
    this.Auth.getUserDetails(this.trabajadorLogIn);
  }
}
