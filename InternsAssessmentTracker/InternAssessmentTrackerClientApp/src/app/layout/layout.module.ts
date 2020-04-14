import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout/layout.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SidemenuComponent } from './sidemenu/sidemenu.component';
import { AppRoutingModule } from '.././app-routing.module';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatBadgeModule } from '@angular/material/badge';
import { MatButtonModule } from '@angular/material/button';
// import { MatChipsModule } from '@angular/material/chips';
// import { MatNativeDateModule } from '@angular/material/core';
// import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
//import { MatPaginatorModule } from '@angular/material/paginator';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatMenuModule } from '@angular/material/menu';
import { MatTableModule } from '@angular/material/table';


@NgModule({
  declarations: [LayoutComponent, NavbarComponent, SidemenuComponent],
  imports: [
    CommonModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatBadgeModule,
    MatButtonModule,
    //MatChipsModule,
   // MatNativeDateModule,
    //MatDatepickerModule,
    MatFormFieldModule,
    //MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    //MatPaginatorModule,
    MatRadioModule,
    MatSelectModule,
    MatMenuModule,
    MatSidenavModule,
    MatToolbarModule,
    MatTableModule
  ],
  exports:[
    LayoutComponent,
    MatBadgeModule,
    MatButtonModule,
    //MatChipsModule,
   // MatNativeDateModule,
    //MatDatepickerModule,
    MatFormFieldModule,
    //MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    //MatPaginatorModule,
    MatRadioModule,
    MatSelectModule,
    MatMenuModule,
    MatSidenavModule,
    MatToolbarModule,
    MatTableModule
  ]
})
export class LayoutModule { }
