import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CandidateSummary, Skill, Team } from '../interfaces/team';
@Injectable({
  providedIn: 'root',
})
export class TeamService {
  private apiUrl = `http://localhost:5185/Team`; // Base URL for your API

  constructor(private http: HttpClient) {}

    // Get all teams
    getTeams(): Observable<Team[]> {
        return this.http.get<Team[]>(this.apiUrl + "/GetAllProfiles");
    }

    // Get Teams By Manager Id
    getTeamById(managerId: string): Observable<Team>  {
        return this.http.get<Team>(`${this.apiUrl}/GetProfileById/${managerId}`);
    }

    // Get Teams By Manager Id
    getTeamSkillsById(teamId: string): Observable<Skill[]>  {
        return this.http.get<Skill[]>(`${this.apiUrl}/GetSkillsById/${teamId}`);
    }

    // Get Candidates By Id
    getCandidatesById(teamId: string): Observable<CandidateSummary[]>  {
        return this.http.get<CandidateSummary[]>(`${this.apiUrl}/FindCandidatesById/${teamId}`);
    }
}
