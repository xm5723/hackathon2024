export interface Candidate {
  uid: string; // Unique identifier
  first_name: string;
  last_name: string;
  email: string; // Unique email
  education?: string; // Optional field
  year_of_graduation?: string; // Optional field
  fun_fact?: string; // Optional field
}

export interface Skill {
  skill_id: string;
  skill_name: string;
  skill_level: string;
}
