using Hackathon2024.Objects;

namespace Hackathon2024
{
    public static class BusinessLogic
    {

        public static IEnumerable<Objects.AnalysisResult> Analyze(IEnumerable<TeamWithSkills> teams, IEnumerable<Objects.CandidateWithSkills> candidates)
        {
            var results = new List<Objects.AnalysisResult>();
            foreach (var team in teams)
            {
                foreach (var candidate in candidates)
                {
                    var result = Analyze(team, candidate);
                    if (result.Score > 0)
                    {
                        results.Add(result);
                    }
                }
            }
            return results.OrderByDescending(i => i.Score);
        }

        public static Objects.AnalysisResult Analyze(TeamWithSkills team, Objects.CandidateWithSkills candidate)
        {
            var score = 0;

            // Do formula/logic to assign a score
            foreach (var skill in team.Skills)
            {
                var candidateMatch = candidate.Skills.Where(i => i.SkillId == skill.SkillId).FirstOrDefault();
                if (candidateMatch != null)
                {
                    score += (candidateMatch.SkillLevel * skill.SkillLevel);
                }
            }

            return new Objects.AnalysisResult()
            {
                Candidate = candidate,
                Team = team,
                Score = score
            };
        }
    }

}
