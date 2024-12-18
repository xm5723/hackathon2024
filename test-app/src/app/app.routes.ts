// src/app/app.routes.ts
import { Route } from '@angular/router';
import { RoleSelectionComponent } from './role-selection/role-selection.component';
import { CandidateComponent } from './candidate/candidate.component';
import { TeamComponent } from './team/team.component';

export const routes: Route[] = [
  { path: '', redirectTo: '/role-selection', pathMatch: 'full' },
  { path: 'role-selection', component: RoleSelectionComponent },
  { path: 'candidate', component: CandidateComponent },
  { path: 'team', component: TeamComponent },
];
