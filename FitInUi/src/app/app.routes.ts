import { provideRouter, Route } from '@angular/router';

import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { ReactiveFormsModule } from '@angular/forms';
import { TeamComponent } from './team/team.component';
import { CandidateComponent } from './candidate/candidate.component';

export const routes: Route[] = [
    { 
        path: 'login', 
        component: LoginComponent 
    },
    { 
        path: 'signup', 
        component: SignupComponent 
    },
    { 
        path: '', 
        redirectTo: '/login', 
        pathMatch: 'full' 
    },
    { 
        path: 'team', 
        component: TeamComponent 
    },
    { 
        path: 'candidate', 
        component: CandidateComponent  
    }
];

  export class AppRoutingModule{}