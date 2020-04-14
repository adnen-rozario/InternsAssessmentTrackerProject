import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { DataComponent } from './pages/data/data.component';
import { InternComponent } from './intern/intern.component';
import { InternProjectComponent } from './internProject/internProject.component';
import { InternratingComponent } from './intern/internrating/internrating.component';
import { AssignprojectComponent } from './intern/assignproject/assignproject.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'data', component: DataComponent },
  { path:'intern', component: InternComponent},
  { path:'project', component: InternProjectComponent},
  { path:'rating/:id', component: InternratingComponent},
  { path:'assignproject/:id', component: AssignprojectComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
