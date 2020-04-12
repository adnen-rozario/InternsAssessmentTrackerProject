import { Component, OnInit } from '@angular/core';
import { SidebarService } from 'src/app/shared/sidebar.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  constructor(private sidebar: SidebarService) { }

  ngOnInit(): void {
  }

  toggleRightSidenav() {
    this.sidebar.toggle();
 }
}
