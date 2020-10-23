import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  mobileMenuActive = false;

  constructor() {
  }

  ngOnInit(): void {
  }

  toggleActive(): void {
    this.mobileMenuActive = !this.mobileMenuActive;
  }

}
