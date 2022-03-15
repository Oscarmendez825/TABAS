import { NgModule } from '@angular/core';

import { RouterModule, Routes } from '@angular/router';

import { BagCartComponent } from './pages/bag-cart/bag-cart.component';
import { CrearMaletasComponent } from './pages/crear-maletas/crear-maletas.component';
import { HomeComponent } from './pages/home/home.component';
import { InformacionComponent } from './pages/informacion/informacion.component';
import { LoginComponent } from './pages/login/login.component';
import { RegistroTrabajadorComponent } from './pages/registro-trabajador/registro-trabajador.component';
import { ReportesComponent } from './pages/reportes/reportes.component';

const routes: Routes = [
  {path: "informacion",component: InformacionComponent},
  {path: "home",component: HomeComponent},
  {path: "BagCart",component: BagCartComponent},
  {path: "login",component: LoginComponent},
  {path: "maletas",component:CrearMaletasComponent},
  {path: "reportes", component: ReportesComponent},
  {path: "registro", component: RegistroTrabajadorComponent},
  {path: "**", redirectTo: "login", pathMatch:"full"},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
