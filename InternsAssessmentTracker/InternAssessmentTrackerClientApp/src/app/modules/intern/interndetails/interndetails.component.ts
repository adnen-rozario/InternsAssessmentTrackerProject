import { Component, OnInit } from '@angular/core';
import { RatingService } from 'src/app/services/rating.service';
import { InternRating } from 'src/app/models/internratingModel';
import { InternRatingResponse } from 'src/app/models/internratingresponseModel';
import { ActivatedRoute } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-interndetails',
  templateUrl: './interndetails.component.html',
  styleUrls: ['./interndetails.component.scss']
})
export class InterndetailsComponent implements OnInit {
  techs=[]; 
 ratings=[{"key":1,"value":"Very Poor"},{"key":2,"value":"Poor"},{"key":3,"value":"Average"},{"key":4,"value":"Good"},{"key":5,"value":"Excellent"}];

  interndetailsrequest:InternRating;
  interndetailsresponse:InternRatingResponse[];
  interndetailssingleresponse:InternRatingResponse;
  projectName:string;
  internName:string;
  projectDescription:string;
  internId:number;
  interndetailsForm:FormGroup;
  email:string;
  phoneno:string;


  constructor(private ratingservice:RatingService,private route: ActivatedRoute) {
    this.route.params.subscribe( params =>{ 
     
      this.internId= params["id"];
    }); 
   }

  ngOnInit(): void {
    
  }

  

  ngAfterViewInit():void{
    this.getInternRatingDetails();
    //this.gettechnologies();
    
    
   }
 
   getInternRatingDetails(){
     //this.interndetailsrequest.internId=this.internId??0;
     console.log(this.internId)

 
 
 
 this.ratingservice.getInternRating({"internId":this.internId,rating:[]}).subscribe((data) =>
        {
         
         if(data)
         {
           console.log(data)
         this.interndetailssingleresponse=data[0];
         this.projectName=data[0].projectName;
         this.internName=data[0].internName;
         this.projectDescription=data[0].projectDescription;
         this.email=data[0].email;
         this.phoneno=data[0].phoneNo;
 
    
 
         
         this.techs=data[0].technologyNameList.map((item,i)=>{
           let container = { "name":"","rating":0};
           
           container.name=item.toString();
           //container.rating=data[0].rating[i];
           container.rating=data[0].ratings[i];
          // this.interndetailsForm.controls[container.name].setValue(container.rating);
           return container;
         });

         console.log(this.techs)
 
        
        //  this.techs.map((item,i)=>{
        //    this.interndetailsForm.controls[item.name].setValue(item.rating);

        //  })
 
 
         
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
