import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Intern } from '../models/internModel';
import { InternService } from '../services/intern.service';
import { HttpErrorResponse } from '@angular/common/http';




@Component({
  selector: 'app-intern',
  templateUrl: './intern.component.html',
  styleUrls: ['./intern.component.scss']
})
export class InternComponent implements OnInit {

  addInternForm: FormGroup;
  internDetails: Intern;
  isShow = false;
  interns: Intern[];

  constructor(private fb: FormBuilder, private internService: InternService) { }

  ngOnInit(): void {
    this.reactiveForm()
    this.getIntern()

  }



  toggleDisplay(event) {
    this.isShow = !this.isShow;

    this.reactiveForm();

    var target = event.target || event.srcElement || event.currentTarget;
    if (target.attributes.id == "cancelButton") {
      this.addInternForm.reset();

    }

  }

  reactiveForm() {
    let emailregex: RegExp = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/

    let phonenoregex = /^((\\+91-?)|0)?[0-9]{10}$/;

    this.addInternForm = this.fb.group({
      name: ['', [Validators.required]],
      emailId: ['', [Validators.required, Validators.pattern(emailregex)]],
      phoneNo: ['', [Validators.required, Validators.pattern(phonenoregex)]],

    })
  }



  AddIntern() {

    if (this.addInternForm.valid) {

      let internDetails = this.addInternForm.value as Intern;

      this.internService.addIntern(internDetails).subscribe((data) => {
        console.log('data returned ' + data);

        if (data) {
          this.isShow = !this.isShow;
        }
      },
        (err: HttpErrorResponse) => {
          console.log("error");
          console.log(err.message);
        }
      );

      console.log(internDetails);
    }
  }

  getIntern() {

    this.internService.getIntern().subscribe((data) => {
      this.interns = data;
      console.log('data returned ' + data);
    },
      (err: HttpErrorResponse) => {
        console.log("error");
        console.log(err.message);
      }
    );

  }

  getErrorEmail() {
    return this.addInternForm.get('emailId').hasError('required') ? '<strong>Email</strong> is required' :
      this.addInternForm.get('emailId').hasError('pattern') ? 'Not a valid Email Address' : '';

  }

  getErrorPhoneNo() {
    return this.addInternForm.get('phoneNo').hasError('required') ? '<strong>Phone No</strong> is required' :
      this.addInternForm.get('phoneNo').hasError('pattern') ? 'Not a valid PhoneNo' : '';

  }

}
