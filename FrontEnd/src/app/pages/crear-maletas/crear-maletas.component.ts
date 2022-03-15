import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiPostService } from 'src/app/components/postService/api-post-service';
import { EstadoModel } from '../models/estado-model';
import { MaletaModel } from '../models/maleta-model';

@Component({
  selector: 'app-crear-maletas',
  templateUrl: './crear-maletas.component.html',
  styleUrls: ['./crear-maletas.component.css']
})
export class CrearMaletasComponent implements OnInit {

  nuevaMaleta: MaletaModel =
  {
    numero_maleta:0,
    cedulaUsuario:0,
    peso:0,
    color:'',
    aceptada: true,
    costo:0
  }

  estadoRes: EstadoModel = {
    estado:""
  }
  constructor(private http: HttpClient, private router: Router, private apiService: ApiPostService) { }
  ngOnInit(): void {
  }

  sendMaleta():void{
    this.apiService.registrarMaleta(this.nuevaMaleta).subscribe(
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
