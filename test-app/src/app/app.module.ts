// src/app/app.module.ts
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router'; // Import RouterModule
import { AppComponent } from './app.component';
import { RoleSelectionComponent } from './role-selection/role-selection.component';
import { CandidateComponent } from './candidate/candidate.component';
import { TeamComponent } from './team/team.component';
import { routes } from './app.routes'; // Import the appRoutes
import { provideHttpClient } from '@angular/common/http';

@NgModule({
  declarations: [
    RoleSelectionComponent, 
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes), // Use appRoutes for routing configuration
    AppComponent,
    CandidateComponent,
    TeamComponent,
  ],
  providers: [provideHttpClient()],
  bootstrap: []
})
export class AppModule { }
