import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { InternRating } from 'src/app/models/internratingModel';
import { RatingService } from 'src/app/services/rating.service';
import { HttpErrorResponse } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { InternRatingResponse } from 'src/app/models/internratingresponseModel';
import { TechRating } from 'src/app/models/techratingModel';

@Component({
  selector: 'app-internrating',
  templateUrl: './internrating.component.html',
  styleUrls: ['./internrating.component.scss']
})
export class InternratingComponent implements OnInit {
 // techs=[{"name":"c#","techId":"1"},{"name":".net","techId":"1"},{"name":"python","techId":"1"},{"name":"java","techId":"1"}];
 techs=[]; 
 ratings=[{"key":1,"value":"Very Poor"},{"key":2,"value":"Poor"},{"key":3,"value":"Average"},{"key":4,"value":"Good"},{"key":5,"value":"Excellent"}];
  
  assignRatingForm:FormGroup;
  interndetailsrequest:InternRating;
  interndetailsresponse:InternRatingResponse[];
  interndetailssingleresponse:InternRatingResponse;
  projectName:string;
  internName:string;
  projectDescription:string;
  show=false;
  
  internId:number;
  constructor(private fb:FormBuilder,private ratingservice:RatingService,private route: ActivatedRoute) {
    this.route.params.subscribe( params =>{ 
     
      this.internId= params["id"];
    }); 
   }

  ngOnInit(): void {
    this.gettechnologies();
  }

  gettechnologies() {
    
    console.log(this.techs);
    this.assignRatingForm = this.createGroup();
  }

  createGroup() {
    const group = this.fb.group({});
    this.techs.forEach(control => group.addControl(control.techId, this.fb.control('',[Validators.required])));
    return group;
  }

  AssignRating(){
if(this.assignRatingForm.valid)
{
  console.log(this.assignRatingForm.value);

  let ab:{}=this.assignRatingForm.value;

  

 let bc= Object.keys(ab).map(function (key) {
  return {"techId":Number(key),"ratingId":Number(ab[key])};
 })

 let cd:InternRating={"internId":this.internId,"rating":bc}

 this.ratingservice.assignInternRating(cd).subscribe((data) =>
       {
      console.log('data returned '+data);

      if(data)
      {
        
      }
      },
      (err: HttpErrorResponse) => {
        console.log("error");
      console.log (err.message);
      }
      );

 console.log(cd)  
  
  // .map(item=>{
  //   let container = { "techId":0,"ratingId":0};
  //   container.techId=item.ratingId;
  //   container.techId=item.techId;

  //   return container;
  // });

}
  }

  ngAfterViewInit():void{
   this.getInternRatingDetails();
   //this.gettechnologies();
   
  }

  getInternRatingDetails(){
    //this.interndetailsrequest.internId=this.internId??0;
    console.log(this.internId)
//console.log(this.interndetailsrequest)



this.ratingservice.getInternRating({"internId":this.internId,rating:[]}).subscribe((data) =>
       {
        //this.interndetailsresponse=data;
        if(data)
        {
          console.log(data)
        this.interndetailssingleresponse=data[0];
        this.projectName=data[0].projectName;
        this.internName=data[0].internName;
        this.projectDescription=data[0].projectDescription;

        //data.map(x=>x.)
        // this.techs=data.map(item=>{
        //   let container = { "name":"","techId":""};
        //   container.name=item.technologyName;
        //   container.techId=item.techId;

        //   return container;
        // });

        
        this.techs=data[0].techIds.map((item,i)=>{
          let container = { "name":"","techId":""};
          
          container.techId=item.toString();
          container.name=data[0].technologyNameList[i];
          return container;
        });


      this.gettechnologies();

        
        }
      console.log(data);

      if(data)
      {
        
      }
      },
      (err: HttpErrorResponse) => {
        console.log("error");
      console.log (err.message);
      }
      );
    
  }

}
