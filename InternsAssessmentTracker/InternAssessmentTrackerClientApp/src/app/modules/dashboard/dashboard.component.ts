import { Component, OnInit } from '@angular/core';
import { InternService } from 'src/app/services/intern.service';
import { Intern } from 'src/app/models/internModel';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {
  internsdashboard:Intern[];
  constructor(private internservice:InternService) {}

  ngOnInit() {

    this.internservice.getInternDashboard().subscribe((data) => {
      this.internsdashboard = data;
      console.log('data returned ' + data);
    },
      (err: HttpErrorResponse) => {
        console.log("error");
        console.log(err.message);
      }
    );
  }
}
