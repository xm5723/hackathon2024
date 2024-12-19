import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TeamService } from '../data-service/team.service';
import { CandidateSummary, Skill, Team } from '../interfaces/team';
import { Router } from '@angular/router';


@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.css'],
  standalone: true,
  imports: [CommonModule]
})
export class TeamComponent {
  constructor(private router: Router) {}
  
  private teamService = inject(TeamService);
  team!: Team;
  candidates: CandidateSummary[] = [];
  skills: Skill[] = [];
  uid: any;
  candidatesDataLoaded: boolean = false;
  skillDataLoaded: boolean = false;
  teamDataLoaded: boolean = false;
  
  ngOnInit(): void {
    const navigation = this.router.getCurrentNavigation();
    if (navigation?.extras.state) {
      this.uid = navigation.extras.state['uid'];
    }
    if (!this.uid) {
      this.uid = "lfHZQ8gEAAQNBP0VddJ9YQ79x6A3";
    }
    console.log(this.uid);
    this.loadTeam(this.uid);
  }

  loadTeam(uid : string): void {
    this.teamService.getTeamById(uid).subscribe((data) => {
      this.team = data;
      this.teamDataLoaded = true;
      this.loadTeamSkills(this.team.id.toString());
    });
  }

  loadTeamSkills(teamId : string): void {
    this.teamService.getTeamSkillsById(teamId).subscribe((data) => {
      this.skills = data;
      this.skillDataLoaded = true;
    });
  }

  calculateTopCandidates() {
    this.teamService.getCandidatesById(this.team.id.toString()).subscribe((data) => {
      this.candidates = data;
      this.candidatesDataLoaded = true;
    });
    }
    
  gotoHome() {
    this.router.navigate(['']);
  }

}
