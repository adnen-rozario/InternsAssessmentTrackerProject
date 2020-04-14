import { Component } from '@angular/core';
import { AdalService } from 'adal-angular4';
import { environment } from '../environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'InternAssessmentTracker';

  public isAuthenticated=false;

  constructor(private adalService: AdalService) 
   {
    
   }
  ngOnInit() 
  {
    this.adalService.init(environment.authConfig);
    this.adalService.handleWindowCallback();
    if(!this.adalService.userInfo.authenticated)
    this.adalService.login();

    this.isAuthenticated= this.adalService.userInfo.authenticated
  }
}
