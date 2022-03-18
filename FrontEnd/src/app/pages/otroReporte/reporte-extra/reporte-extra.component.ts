import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ApiGetService } from 'src/app/components/getService/api-get-service';
import { ReporteModel } from '../../models/reporte-model';
import {jsPDF} from "jspdf";

@Component({
  selector: 'app-reporte-extra',
  templateUrl: './reporte-extra.component.html',
  styleUrls: ['./reporte-extra.component.css']
})
export class ReporteExtraComponent implements OnInit {

  reportes: ReporteModel[] = [];
  constructor(private apiService:ApiGetService) { }

  ngOnInit(): void {
    this.getReporte();
  }

  @ViewChild('content', {static: false})el!:ElementRef;
  makePDF(){
    let pdf = new jsPDF('p','pt','a4');
    pdf.html(this.el.nativeElement,{
      callback: (pdf) => {
        pdf.save("ReporteVuelos.pdf");
      }
    });
  }

  public getReporte(){
    this.apiService.getReporte().subscribe(
      res => {
        this.reportes = res;
      },
      err => {
        alert("Ha habido un error")
      }

    );
  }
}
