import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AdalService, AdalGuard } from 'adal-angular4';
import { AuthenticationGuard } from './Guards/authentication.guard';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LayoutModule } from './layout/layout.module';
import { DashboardComponent } from './modules/dashboard/dashboard.component';
import { SidebarService } from './shared/sidebar.service';
import { InternService } from './services/intern.service';
import { InternComponent } from './modules/intern/intern.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { InternProjectComponent } from './modules/internProject/internProject.component';
import { ProjectService } from './services/project.service';
import { InternratingComponent } from './modules/intern/internrating/internrating.component';
import { AssignprojectComponent } from './modules/intern/assignproject/assignproject.component';
import { RatingService } from './services/rating.service';
import { NotificationService } from './shared/notification/notification.service';
import { ToastrModule } from 'ngx-toastr';
import { InterndetailsComponent } from './modules/intern/interndetails/interndetails.component';

@NgModule({
  declarations: [AppComponent, DashboardComponent, InternComponent, InternProjectComponent, InternratingComponent, AssignprojectComponent, InterndetailsComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    

    LayoutModule,
    AppRoutingModule,
    ReactiveFormsModule,
    ToastrModule.forRoot(),
    HttpClientModule
  ],
  providers: [SidebarService,InternService,ProjectService,RatingService,AdalGuard,AdalService,AuthenticationGuard,NotificationService],
  bootstrap: [AppComponent],
})
export class AppModule {}
