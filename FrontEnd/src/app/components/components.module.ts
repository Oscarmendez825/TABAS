import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { ContentComponent } from './content/content.component';
import { FooterComponent } from './footer/footer.component';
import { TableComponent } from './table/table.component';
import { RouterModule} from '@angular/router';


@NgModule({
  declarations: [
    HeaderComponent,
    ContentComponent,
    FooterComponent,
    TableComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
  ],
  exports:[
    HeaderComponent,
    FooterComponent,
    ContentComponent,
    TableComponent
  ]
})
export class ComponentsModule { }
