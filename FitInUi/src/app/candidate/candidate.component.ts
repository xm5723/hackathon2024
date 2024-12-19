import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common'; // <-- Import CommonModule

import { CandidateService } from '../data-service/candidate.service';
import { Skill, Candidate } from '../interfaces/candidate';
import { ActivatedRoute, Router } from '@angular/router';

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
  uid: any;
  candidatesDataLoaded: boolean = false;
  skillDataLoaded: boolean = false;
  candidateDataLoaded: boolean = false;
  
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
    this.candidateService.getCandidateById(uid).subscribe((data) => {
      this.profile = data;
      console.log(this.profile);
      this.candidateDataLoaded = true;
      this.loadCandidateSkills(uid);
    });
  }

  loadCandidateSkills(candidateId : string): void {
    this.candidateService.getCandidateSkillsById(candidateId).subscribe((data) => {
      this.skills = data;
      this.skillDataLoaded = true;
    });
  }

  gotoHome() {
    this.router.navigate(['']);
  }
}