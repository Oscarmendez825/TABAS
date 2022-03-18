import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ApiPostService } from '../components/postService/api-post-service';
import { EstadoModel } from '../pages/models/estado-model';
import { TrabajadorModel } from '../pages/models/trabajador-model.model';

@Injectable({
  providedIn: 'root'
})
/**
 * @description Clase para validar el inicio de sesión
 */
export class AuthService {
  estadoRes: EstadoModel = {
    estado:""
  }
  /**
   * @description Método constructor
   * @param http 
   * @param apiService 
   * @param router 
   */
  constructor(private http: HttpClient, private apiService: ApiPostService,private router:Router) {}

  private loggedInStatus=false;

  
  setLoggedIn(value:boolean){
    this.loggedInStatus=value;
  }

  get isLoggedIn(){
    return this.loggedInStatus;
  }
  /**
   * @description Método utilizado para validar la información del inicio de sesión
   * @param trabajador 
   */
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
