import { Component } from '@angular/core';

/*
 THIS COMPONENT IS PART of the boiler-plate code, when you create a fresh ASP .NET core app
that's wired to an Angular Front-end application
THIS ARTIFACT is vestigial structure of the project & have been left behind for the sake of studying the structure
For this studio this component and the code is inoperative vis-a-vis the DATABASE & the FRONT-END Angular application
 */

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
