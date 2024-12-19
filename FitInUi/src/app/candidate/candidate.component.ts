import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common'; // <-- Import CommonModule

import { CandidateService } from '../data-service/candidate.service';
import { Skill, Candidate, TeamSummary } from '../interfaces/candidate';
import { ActivatedRoute, Router } from '@angular/router';
import { Team } from '../interfaces/team';

@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.css'],
  standalone: true,
  imports: [CommonModule]
})
export class CandidateComponent {
constructor(private router: Router, private route: ActivatedRoute) {}
  
  private candidateService = inject(CandidateService);
  profile!: Candidate;
  skills: Skill[] = [];
  teams: TeamSummary[] = [];
  uid: any;
  skillDataLoaded: boolean = false;
  teamDataLoaded: boolean = false;
  
  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.uid = params['uid'];
    });
    //FallBack just incase
    if (!this.uid) {
      this.uid = "5f73CMP9lQdRmTLugdDP6xbGhS72";
    }
    this.loadCandidate(this.uid);
  }

  loadCandidate(uid : string): void {
    this.uid = uid;
    this.candidateService.getCandidateById(uid).subscribe((data) => {
      this.profile = data;
      console.log(this.profile);
      this.loadCandidateSkills(uid);
    });
  }

  loadCandidateSkills(candidateId : string): void {
    this.candidateService.getCandidateSkillsById(candidateId).subscribe((data) => {
      this.skills = data;
        this.skills.sort((a, b) => parseInt(b.skill_level) - parseInt(a.skill_level));
      this.skillDataLoaded = true;
    });
  }

  calculateTopTeams() {
    this.candidateService.getTeamsById(this.uid).subscribe((data) => {
      this.teams = data;
      console
      this.teamDataLoaded = true;
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