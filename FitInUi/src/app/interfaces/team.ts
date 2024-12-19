export interface Team {
  id: number;
  team_name: string;
  manager_uid: string;
  team_location: string;
  team_members: string; // Comma-separated string of team members
  projects: string; // Comma-separated string of projects
  organization: string;
  net_promoter_score: number; // Decimal value
}

export interface Skill {
  skill_id: string;
  skill_name: string;
  skill_level: string;
}

export interface CandidateSummary {
  candidateName: string;
  score: number;
};