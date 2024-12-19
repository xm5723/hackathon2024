import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TeamService } from '../data-service/team.service';
import { CandidateSummary, Skill, Team } from '../interfaces/team';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.css'],
  standalone: true,
  imports: [CommonModule]
})
export class TeamComponent {
  constructor(private router: Router, private route: ActivatedRoute) {}
  
  private teamService = inject(TeamService);
  team!: Team;
  candidates: CandidateSummary[] = [];
  skills: Skill[] = [];
  uid: any;
  candidatesDataLoaded: boolean = false;
  
  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.uid = params['uid'];
    });
    if (!this.uid) {
      this.uid = "lfHZQ8gEAAQNBP0VddJ9YQ79x6A3";
    }
    this.loadTeam(this.uid);
  }

  loadTeam(uid : string): void {
    this.teamService.getTeamById(uid).subscribe((data) => {
      this.team = data;
      this.loadTeamSkills(this.team.id.toString());
    });
  }

  loadTeamSkills(teamId : string): void {
    this.teamService.getTeamSkillsById(teamId).subscribe((data) => {
      this.skills = data;
      this.skills.sort((a, b) => parseInt(b.skill_level) - parseInt(a.skill_level));
    });
  }

  calculateTopCandidates() {
    this.teamService.getCandidatesById(this.team.id.toString()).subscribe((data) => {
      this.candidates = data;
      this.candidatesDataLoaded = true;
      window.scrollTo({
        top: document.body.scrollHeight,
        behavior: 'smooth'
      });
    });
  }
    
  gotoHome() {
    this.router.navigate(['']);
  }
}
