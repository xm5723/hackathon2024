import { Component } from '@angular/core';
import { CommonModule } from '@angular/common'; // <-- Import CommonModule


@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.css'],
  standalone: true,
  imports: [CommonModule]
})
export class TeamComponent {
  // Team's profile data
  teamProfile = {
    name: 'Team Alpha',
    description: 'A group of skilled developers.',
    createdYear: 2015,
    specialization: 'Software Development',
    manager: 'Alice Johnson'
  };

  // List of candidates available
  candidates = [
    { name: 'Jane Smith', role: 'Candidate', skills: 'JavaScript, Angular' },
    { name: 'Alice Johnson', role: 'Candidate', skills: 'Python, Django' },
    { name: 'Bob Brown', role: 'Candidate', skills: 'Java, Spring Boot' },
    { name: 'Charlie Davis', role: 'Candidate', skills: 'React, Node.js' },
    { name: 'Eva White', role: 'Candidate', skills: 'SQL, PostgreSQL' },
    { name: 'John Doe', role: 'Candidate', skills: 'C#, .NET' },
    // Add more candidates if needed
  ];

  // Set the selected candidate by default (first candidate)
  selectedCandidate = this.candidates[0];
}
