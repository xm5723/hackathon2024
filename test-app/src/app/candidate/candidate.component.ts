import { Component } from '@angular/core';
import { CommonModule } from '@angular/common'; // <-- Import CommonModule

@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.css'],
  standalone: true,
  imports: [CommonModule]
})
export class CandidateComponent {
  // Candidate's profile data
  profile = {
    name: 'John Doe',
    education: 'Masters at UPenn',
    graduationYear: 2001,
    funFact: 'Lost all my teeth in a ski accident',
    skills: 'Not skiing',
    interests: 'snowboarding!!',
    role: 'Candidate'
  };

  // List of teams available
  teams = [
    { name: 'Team Alpha', description: 'A group of skilled developers.' },
    { name: 'Team Beta', description: 'Creative designers focused on UI/UX.' },
    { name: 'Team Gamma', description: 'Marketing and outreach specialists.' },
    { name: 'Team Delta', description: 'Project management and coordination.' },
    { name: 'Team Epsilon', description: 'Data scientists and machine learning experts.' },
    { name: 'Team Zeta', description: 'Customer support and feedback gathering.' },
    // Add more teams if needed
  ];

  // Set the selected team by default (first team)
  selectedTeam = this.teams[0];
}
