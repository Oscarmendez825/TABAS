import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ApiGetService } from 'src/app/components/getService/api-get-service';
import { MaletaModel } from '../models/maleta-model';
import {jsPDF} from "jspdf";
@Component({
  selector: 'app-reportes',
  templateUrl: './reportes.component.html',
  styleUrls: ['./reportes.component.css']
})
export class ReportesComponent implements OnInit {
  maletas: MaletaModel[] = [];

  constructor(private apiService:ApiGetService) { }

  ngOnInit(): void {
    this.getElements();
  }


  @ViewChild('content', {static: false})el!:ElementRef;
  makePDF(){
    let pdf = new jsPDF('p','pt',[220,278]);
    pdf.html(this.el.nativeElement,{
      callback: (pdf) => {
        pdf.save("ReporteMaletas.pdf");
      }
    });
  }
  
  public getElements(){
    this.apiService.getMaletas().subscribe(
      res => {
        this.maletas = res;
      },
      err => {
        alert("Ha habido un error")
      }
      
    );
  }
}
