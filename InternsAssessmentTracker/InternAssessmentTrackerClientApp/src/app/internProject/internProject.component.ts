import { Component, OnInit } from '@angular/core';
import { KeyValue } from '../models/keyvalueModel';
import { ProjectService } from '../services/project.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Subscription } from 'rxjs';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Project } from '../models/projectModel';

@Component({
  selector: 'app-internproject',
  templateUrl: './internProject.component.html',
  styleUrls: ['./internProject.component.scss']
})
export class InternProjectComponent implements OnInit {
  technologiesList:KeyValue[];
  selectedTechnologies;
  subscription: Subscription;
  addProjectForm: FormGroup;
  isShow = false;
  projs:Project[];


  constructor(private projectService:ProjectService,private fb: FormBuilder) { }

  ngOnInit(): void {
    
    this.reactiveForm();
    this.getProjects();
  }

  toggleDisplay(event) {
    this.isShow = !this.isShow;
    
    this.reactiveForm();

    var target = event.target || event.srcElement || event.currentTarget;
    if(target.attributes.id=="cancelButton")
    {
      this.addProjectForm.reset();
    
      
    }

  }

  reactiveForm() {

    this.addProjectForm = this.fb.group({
      projectName: ['', [Validators.required]],
      projectDescription: ['', [Validators.required]],
      techId: ['', [Validators.required]]
     
    })
  }

  AddProject() {
    if(this.addProjectForm.valid)
     {  
      let projectDetails=this.addProjectForm.value as Project;

      this.projectService.addProject(projectDetails).subscribe((data) =>
       {
      console.log('data returned '+data);
      },
      (err: HttpErrorResponse) => {
        console.log("error");
      console.log (err.message);
      }
      );
     }

  }

  ngAfterViewInit():void{
    this.subscription= this.projectService.getTechnologies().subscribe((data) =>
    {
      this.technologiesList = data as KeyValue[]
   },
   (err: HttpErrorResponse) => {
     console.log("error");
   console.log (err.message);
   }
   );
  }

  getProjects()
{
  
  this.projectService.getProject().subscribe((data) =>
  {
    this.projs=data as Project[];
 console.log(this.projs);
 },
 (err: HttpErrorResponse) => {
   console.log("error");
 console.log (err.message);
 }
 );

}

//   ngOnDestroy() {
//     this.subscription.unsubscribe()
// }

}
