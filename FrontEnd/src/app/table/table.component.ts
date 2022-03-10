import { Component, OnInit } from '@angular/core';

interface Trabajadores {
  name: string;
  lastName: string;
  id: number;
  rol: string;
}

const TRAB: Trabajadores[] = [
  {
    name: 'Aldo',
    lastName: "Cambronero",
    id: 17075,
    rol: "Scan"
  },
  {
    name: 'Aldo1',
    lastName: "Cambronero1",
    id: 17076,
    rol: "Embarcador"
  },
  {
    name: 'Aldo2',
    lastName: "Cambronero2",
    id: 17078,
    rol: "Admin"
  },
  {
    name: 'Aldo3',
    lastName: "Cambronero3",
    id: 17077,
    rol: "Recepcionista"
  },
  {
    name: 'Aldo',
    lastName: "Cambronero",
    id: 17075,
    rol: "Scan"
  },
  {
    name: 'Aldo1',
    lastName: "Cambronero1",
    id: 17076,
    rol: "Embarcador"
  },
  {
    name: 'Aldo2',
    lastName: "Cambronero2",
    id: 17078,
    rol: "Admin"
  },
  {
    name: 'Aldo3',
    lastName: "Cambronero3",
    id: 17077,
    rol: "Recepcionista"
  },
  {
    name: 'Aldo',
    lastName: "Cambronero",
    id: 17075,
    rol: "Scan"
  },
  {
    name: 'Aldo1',
    lastName: "Cambronero1",
    id: 17076,
    rol: "Embarcador"
  },
  {
    name: 'Aldo2',
    lastName: "Cambronero2",
    id: 17078,
    rol: "Admin"
  },
  {
    name: 'Aldo3',
    lastName: "Cambronero3",
    id: 17077,
    rol: "Recepcionista"
  },
  {
    name: 'Aldo',
    lastName: "Cambronero",
    id: 17075,
    rol: "Scan"
  },
  {
    name: 'Aldo1',
    lastName: "Cambronero1",
    id: 17076,
    rol: "Embarcador"
  },
  {
    name: 'Aldo2',
    lastName: "Cambronero2",
    id: 17078,
    rol: "Admin"
  },
  {
    name: 'Aldo3',
    lastName: "Cambronero3",
    id: 17077,
    rol: "Recepcionista"
  }
];


@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent implements OnInit {

  constructor() { }
  trabajadores = TRAB;
  ngOnInit(): void {
  }

}
