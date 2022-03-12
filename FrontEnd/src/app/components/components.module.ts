import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { TableComponent } from './table/table.component';

@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    TableComponent
  ],
  imports: [
    CommonModule,
  ],
  exports:[
    HeaderComponent,
    FooterComponent,
    TableComponent
  ]
})
export class ComponentsModule { }
