import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter, Routes } from '@angular/router';
import { AppComponent } from './app/app.component';
import { LoginComponent } from './app/login/login.component';
import { SignupComponent } from './app/signup/signup.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { TeamComponent } from './app/team/team.component';
import { CandidateComponent } from './app/candidate/candidate.component';

export const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'team', component: TeamComponent },
  { path: 'candidate', component: CandidateComponent  }
];

bootstrapApplication(AppComponent, {
  providers: [provideRouter(routes), HttpClientModule, ReactiveFormsModule],
}).catch((err) => console.error(err));