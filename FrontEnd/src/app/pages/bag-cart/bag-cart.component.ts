import { Component, OnInit } from '@angular/core';
import { ApiGetService } from 'src/app/components/getService/api-get-service';
import { BagCartModel } from '../models/bag-cart-model';
import { VueloModel } from '../models/vuelo-model';

@Component({
  selector: 'app-bag-cart',
  templateUrl: './bag-cart.component.html',
  styleUrls: ['./bag-cart.component.css']
})
export class BagCartComponent implements OnInit {

  vuelos: VueloModel[] = [];
  BC: BagCartModel[] = [];
  constructor(private apiService:ApiGetService) { }

  ngOnInit(): void {
    this.getElements();
    
  }

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
}
