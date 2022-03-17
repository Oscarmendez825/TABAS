import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ApiPostService } from '../components/postService/api-post-service';
import { EstadoModel } from '../pages/models/estado-model';
import { TrabajadorModel } from '../pages/models/trabajador-model.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  estadoRes: EstadoModel = {
    estado:""
  }
  constructor(private http: HttpClient, private apiService: ApiPostService,private router:Router) {}

  private loggedInStatus=false;

  setLoggedIn(value:boolean){
    this.loggedInStatus=value;
  }

  get isLoggedIn(){
    return this.loggedInStatus;
  }
  getUserDetails(trabajador:TrabajadorModel){
    this.apiService.IniciarSesion(trabajador).subscribe(
      res =>{
        this.estadoRes = res;
        if(this.estadoRes.estado == "OK"){
          window.alert("BIENVENIDO");
          this.router.navigate(["home"]);
          this.setLoggedIn(true);
        }else{
          window.alert("CONTRASEÑA O CÉDULA INCORRECTOS")
        }    
      }
    );
  }
}
