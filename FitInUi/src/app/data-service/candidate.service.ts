import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Skill, Candidate, TeamSummary } from '../interfaces/candidate';
@Injectable({
  providedIn: 'root',
})
export class CandidateService {
  private apiUrl = `http://localhost:5185/Candidate`; // Base URL for your API

  constructor(private http: HttpClient) {}

    // Get all Candidates
    getCandidates(): Observable<Candidate[]> {
        return this.http.get<Candidate[]>(this.apiUrl + "/GetAllProfiles");
    }

    // Get Profile By Candidate Id
    getCandidateById(candidateId: string): Observable<Candidate>  {
        return this.http.get<Candidate>(`${this.apiUrl}/GetProfileById/${candidateId}`);
    }

    // Get Skills By Candidate Id
    getCandidateSkillsById(candidateId: string): Observable<Skill[]>  {
        return this.http.get<Skill[]>(`${this.apiUrl}/GetSkillsById/${candidateId}`);
    }

    // Get Teams By Id
    getTeamsById(candidateId: string): Observable<TeamSummary[]>  {
        return this.http.get<TeamSummary[]>(`${this.apiUrl}/FindTeamsById/${candidateId}`);
    }
}
