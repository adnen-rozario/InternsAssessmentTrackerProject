import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
// import { MatButtonModule } from '@angular/material/button';
// import { MatIconModule } from '@angular/material/icon';
// import { MatListModule } from '@angular/material/list';
// import { MatMenuModule } from '@angular/material/menu';
// import { MatSidenavModule } from '@angular/material/sidenav';
// import { MatToolbarModule } from '@angular/material/toolbar';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LayoutModule } from './layout/layout.module';
import { HomeComponent } from './pages/home/home.component';
import { DataComponent } from './pages/data/data.component';
import { SidebarService } from './shared/sidebar.service';

@NgModule({
  declarations: [AppComponent, HomeComponent, DataComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    // MatIconModule,
    // MatButtonModule,
    // MatMenuModule,
    // MatListModule,
    // MatToolbarModule,
    // MatSidenavModule,
    LayoutModule,
    AppRoutingModule,
  ],
  providers: [SidebarService],
  bootstrap: [AppComponent],
})
export class AppModule {}
