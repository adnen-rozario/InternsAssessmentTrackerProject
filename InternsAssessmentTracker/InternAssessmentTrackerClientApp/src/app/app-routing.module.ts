import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { InternComponent } from './intern/intern.component';
import { InternProjectComponent } from './internProject/internProject.component';
import { InternratingComponent } from './intern/internrating/internrating.component';
import { AssignprojectComponent } from './intern/assignproject/assignproject.component';
import { AuthenticationGuard } from './Guards/authentication.guard';


const routes: Routes = [
  { path: '',canActivate:[AuthenticationGuard], component: HomeComponent },
  { path:'intern', canActivate:[AuthenticationGuard], component: InternComponent},
  { path:'project',canActivate:[AuthenticationGuard], component: InternProjectComponent},
  { path:'rating/:id',canActivate:[AuthenticationGuard], component: InternratingComponent},
  { path:'assignproject/:id',canActivate:[AuthenticationGuard], component: AssignprojectComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
