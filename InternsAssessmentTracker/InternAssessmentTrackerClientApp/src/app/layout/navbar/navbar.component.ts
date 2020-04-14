import { Component, OnInit } from '@angular/core';
import { SidebarService } from 'src/app/shared/sidebar.service';
import { AdalService } from 'adal-angular4';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  constructor(private sidebar: SidebarService,private adalService:AdalService) { }

  ngOnInit(): void {
  }

  toggleRightSidenav() {
    this.sidebar.toggle();
 }

 LogOut()
    {
      this.adalService.logOut();
    }
}
