import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AdalService, AdalGuard } from 'adal-angular4';
import { AuthenticationGuard } from './Guards/authentication.guard';

// import { MatBadgeModule } from '@angular/material/badge';
// import { MatButtonModule } from '@angular/material/button';
// import { MatChipsModule } from '@angular/material/chips';
// import { MatNativeDateModule } from '@angular/material/core';
// import { MatDatepickerModule } from '@angular/material/datepicker';
// import { MatFormFieldModule } from '@angular/material/form-field';
// import { MatGridListModule } from '@angular/material/grid-list';
// import { MatIconModule } from '@angular/material/icon';
// import { MatInputModule } from '@angular/material/input';
// import { MatListModule } from '@angular/material/list';
// import { MatPaginatorModule } from '@angular/material/paginator';
// import { MatRadioModule } from '@angular/material/radio';
// import { MatSelectModule } from '@angular/material/select';
// import { MatSidenavModule } from '@angular/material/sidenav';
// import { MatToolbarModule } from '@angular/material/toolbar';
// import { MatMenuModule } from '@angular/material/menu';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LayoutModule } from './layout/layout.module';
import { HomeComponent } from './pages/home/home.component';
import { DataComponent } from './pages/data/data.component';
import { SidebarService } from './shared/sidebar.service';
import { InternService } from './services/intern.service';
import { InternComponent } from './intern/intern.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { InternProjectComponent } from './internProject/internProject.component';
import { ProjectService } from './services/project.service';
import { InternratingComponent } from './intern/internrating/internrating.component';
import { AssignprojectComponent } from './intern/assignproject/assignproject.component';
import { RatingService } from './services/rating.service';

@NgModule({
  declarations: [AppComponent, HomeComponent, DataComponent, InternComponent, InternProjectComponent, InternratingComponent, AssignprojectComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    
    // MatBadgeModule,
    // MatButtonModule,
    // MatChipsModule,
    // MatNativeDateModule,
    // MatDatepickerModule,
    // MatFormFieldModule,
    // MatGridListModule,
    // MatIconModule,
    // MatInputModule,
    // MatListModule,
    // MatPaginatorModule,
    // MatRadioModule,
    // MatSelectModule,
    // MatMenuModule,
    // MatSidenavModule,
    // MatToolbarModule,

    LayoutModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [SidebarService,InternService,ProjectService,RatingService,AdalGuard,AdalService,AuthenticationGuard],
  bootstrap: [AppComponent],
})
export class AppModule {}
