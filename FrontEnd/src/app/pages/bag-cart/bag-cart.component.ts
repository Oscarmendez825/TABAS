import { Component, OnInit } from '@angular/core';
import { ApiGetService } from 'src/app/components/getService/api-get-service';
import { ApiPostService } from 'src/app/components/postService/api-post-service';
import { BagCartModel } from '../models/bag-cart-model';
import { EstadoModel } from '../models/estado-model';
import { VueloModel } from '../models/vuelo-model';

@Component({
  selector: 'app-bag-cart',
  templateUrl: './bag-cart.component.html',
  styleUrls: ['./bag-cart.component.css']
})

/**
 * @description: Clase utilizada para todo el form de asignación de BagCart
 */
export class BagCartComponent implements OnInit {

  vuelos: VueloModel[] = [];
  BC: BagCartModel[] = [];

  vueloTemp: VueloModel = {
    numVuelo: 0,
    BC_ID:0,
    placaAvion: 0,
    capacidad: 0,
    numMaletas: 0,
    origen: '',
    destino: ''

  }
  estadoRes: EstadoModel = {
    estado:""
  }
  /**
   * @description: Método constructor
   * @param apiService 
   * @param apiService1 
   */
  constructor(private apiService:ApiGetService, private apiService1: ApiPostService) { }

  
  ngOnInit(): void {
    this.getElements();
    
  }
  /**
   * @description: Método encargado de solicitar todos los vuelos, bagcarts que hayan en la DB
   */
  public getElements(){

    this.apiService.getVuelos().subscribe(
      res => {
        this.vuelos = res;
      },
      err => {
        alert("Ha habido un error")
      }

    );

    this.apiService.getBC().subscribe(
      res => {
        this.BC = res;
      },
      err => {
        alert("Ha habido un error")
      }

    );
  }
  /**
   * @description: Método encargado de asignar un BC a un vuelo
   */
  public asignarBC(){
    this.apiService1.asignarBagCart(this.vueloTemp).subscribe(
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
