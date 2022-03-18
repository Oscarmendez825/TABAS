import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';


@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
  ],
  imports: [
    CommonModule,
  ],
  exports:[
    HeaderComponent,
    FooterComponent,
  ]
})
/**
 * @description Clase para los componentes
 */
export class ComponentsModule { }
