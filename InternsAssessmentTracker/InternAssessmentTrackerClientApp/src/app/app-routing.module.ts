import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './modules/dashboard/dashboard.component';
import { InternComponent } from './modules/intern/intern.component';
import { InternProjectComponent } from './modules/internProject/internProject.component';
import { InternratingComponent } from './modules/intern/internrating/internrating.component';
import { AssignprojectComponent } from './modules/intern/assignproject/assignproject.component';
import { AuthenticationGuard } from './Guards/authentication.guard';
import { InterndetailsComponent } from './modules/intern/interndetails/interndetails.component';



const routes: Routes = [
  { path: '',canActivate:[AuthenticationGuard], component: DashboardComponent },
  { path:'intern', canActivate:[AuthenticationGuard], component: InternComponent},
  { path:'project',canActivate:[AuthenticationGuard], component: InternProjectComponent},
  { path:'rating/:id',canActivate:[AuthenticationGuard], component: InternratingComponent},
  { path:'assignproject/:id',canActivate:[AuthenticationGuard], component: AssignprojectComponent},
  { path:'intern/:id',canActivate:[AuthenticationGuard], component: InterndetailsComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
