import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InformacionComponent } from './informacion/informacion.component';
import { HomeComponent } from './home/home.component';
import { BagCartComponent } from './bag-cart/bag-cart.component';
import { LoginComponent } from './login/login.component';
import { CrearMaletasComponent } from './crear-maletas/crear-maletas.component';
import { ReportesComponent } from './reportes/reportes.component';
import { RegistroTrabajadorComponent } from './registro-trabajador/registro-trabajador.component';
import { ComponentsModule } from '../components/components.module';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    InformacionComponent,
    HomeComponent,
    BagCartComponent,
    LoginComponent,
    CrearMaletasComponent,
    ReportesComponent,
    RegistroTrabajadorComponent,
  ],
  imports: [
    CommonModule,
    ComponentsModule,
    RouterModule
  ],
  exports:[
    LoginComponent,
  ]
})
export class PagesModule { }
