import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AssignProject } from 'src/app/models/assignprojectModel';
import { ActivatedRoute, Router } from '@angular/router';
import { ProjectService } from 'src/app/services/project.service';
import { KeyValue } from 'src/app/models/keyvalueModel';
import { HttpErrorResponse } from '@angular/common/http';
import { NotificationService ,NotifcationType,Position} from 'src/app/shared/notification/notification.service';

@Component({
  selector: 'app-assignproject',
  templateUrl: './assignproject.component.html',
  styleUrls: ['./assignproject.component.scss']
})
export class AssignprojectComponent implements OnInit {
  assignProjectForm:FormGroup;
  assignProjDetails:AssignProject;
  internId:number;
  projectsList:KeyValue[];
  mentorList:KeyValue[];

  constructor(private fb:FormBuilder,private route: ActivatedRoute,private projectservice:ProjectService,private notificationservice:NotificationService,private router: Router) {
    this.route.params.subscribe( params =>{ 
     
      this.internId= params["id"];
    }); 
   }

  ngOnInit(): void {
    this.reactiveForm();
    

     this.getProjects();
     this.getMentors();
  }

  reactiveForm() {
   
    this.assignProjectForm = this.fb.group({
      projId: ['', [Validators.required]],
      mentorId: ['', [Validators.required]]

     
    })
  }

  AssignProject(){
    if(this.assignProjectForm.valid)
  {
    this.assignProjDetails=this.assignProjectForm.value as AssignProject;
    this.assignProjDetails.internId=this.internId;

    

    this.projectservice.assignProject(this.assignProjDetails).subscribe((data) =>
       {
      console.log('data returned '+data);

      if(data)
      {
        this.notificationservice.show("","Project and Mentor assigned successfully",NotifcationType.success,Position.bottomRight)
        this.router.navigateByUrl('/intern');
      }
      },
      (err: HttpErrorResponse) => {
        console.log("error");
      console.log (err.message);
      }
      );

   }
  }

  getProjects(){
    this.projectservice.getProjectNames().subscribe((data) =>
    {
      this.projectsList=data;
   console.log('data returned '+data);
   },
   (err: HttpErrorResponse) => {
     console.log("error");
   console.log (err.message);
   }
   );
  }

  getMentors(){
    this.projectservice.getMentorNames().subscribe((data) =>
    {
      this.mentorList=data;
   console.log('data returned '+data);
   },
   (err: HttpErrorResponse) => {
     console.log("error");
   console.log (err.message);
   }
   );
  }

}
