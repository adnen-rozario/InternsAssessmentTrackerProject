import { Component, OnInit, ViewChild } from '@angular/core';
import { SidebarService } from 'src/app/shared/sidebar.service';
import { MatSidenav } from '@angular/material/sidenav';

@Component({
  selector: 'app-sidemenu',
  templateUrl: './sidemenu.component.html',
  styleUrls: ['./sidemenu.component.scss']
})
export class SidemenuComponent implements OnInit {
  @ViewChild('sidenav') sidenav: MatSidenav;
  constructor(private sidebarservice: SidebarService) { }

  ngOnInit(): void {
 
 
  }

  ngAfterViewInit():void{
    this.sidebarservice.setSidenav(this.sidenav); 

  }

}
