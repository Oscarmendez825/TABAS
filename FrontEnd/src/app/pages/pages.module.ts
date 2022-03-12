import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InformacionComponent } from './informacion/informacion.component';
import { HomeComponent } from './home/home.component';
import { BagCartComponent } from './bag-cart/bag-cart.component';
import { LoginComponent } from './login/login.component';
import { CrearMaletasComponent } from './crear-maletas/crear-maletas.component';
import { ReportesComponent } from './reportes/reportes.component';

@NgModule({
  declarations: [
    InformacionComponent,
    HomeComponent,
    BagCartComponent,
    LoginComponent,
    CrearMaletasComponent,
    ReportesComponent,
  ],
  imports: [
    CommonModule,
  ]
})
export class PagesModule { }
