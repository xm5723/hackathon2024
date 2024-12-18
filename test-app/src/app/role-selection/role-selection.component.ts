import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-role-selection',
  templateUrl: './role-selection.component.html',
  styleUrls: ['./role-selection.component.css']
})
export class RoleSelectionComponent {

  constructor(private router: Router) {}

  selectRole(role: string) {
    if (role === 'candidate') {
      this.router.navigate(['/candidate']);
    } else {
      this.router.navigate(['/team']);
    }
  }
}
