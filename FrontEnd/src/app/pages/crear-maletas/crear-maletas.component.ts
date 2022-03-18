import { HttpClient } from '@angular/common/http';
import { Component, OnInit,ElementRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { ApiPostService } from 'src/app/components/postService/api-post-service';
import { EstadoModel } from '../models/estado-model';
import { MaletaModel } from '../models/maleta-model';
import jsPDF from 'jspdf';

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
    bagcartId:0,
    numVuelo:0,
    peso:0,
    color:'',
    aceptada: true,
    costo:0,
    scanId:0
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
  clave=Math.floor(Math.random() * (999999 - 100000 + 1)) + 100000;
  today = new Date().toISOString().slice(0, 10)
  FechaEmisor=this.today;
  MontoTotal=Math.floor(Math.random() * (999 - 100 + 1)) + 100;
  NumReceptor="25394000";
  Mensaje="Compra de maleta";
  DetalleMen="N.R";
  @ViewChild('content', {static: false})el!:ElementRef;

  makePD(): void{
    let pdf = new jsPDF('p','pt','a4');
    pdf.html(this.el.nativeElement,{
      callback: (pdf) => {
        pdf.save("Factura electronica.pdf");
      }
    });
  }
}
