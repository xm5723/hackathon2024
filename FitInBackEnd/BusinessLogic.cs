using Hackathon2024.Objects;

namespace Hackathon2024
{
    public class BusinessLogic
    {
        DataLayer _dataLayer;

        public BusinessLogic(DataLayer dataLayer) 
        {
            _dataLayer = dataLayer;
        }


        public IEnumerable<Objects.AnalysisResult> Analyze(IEnumerable<TeamWithSkills> teams, IEnumerable<Objects.CandidateWithSkills> candidates)
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

        public Objects.AnalysisResult Analyze(TeamWithSkills team, Objects.CandidateWithSkills candidate)
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

        public async Task<IEnumerable<TeamAnalysisSummary>> MatchCandidateWithTeams(string candidateId, int? max)
        {
            var summaries = new List<TeamAnalysisSummary>();

            var candidate = new CandidateWithSkills()
            { 
                CandidateId = candidateId,
                Skills = await _dataLayer.GetCandidateSkills(candidateId)
            };

            var teams = await _dataLayer.GetAllTeamsWithSkills();

            // Do analysis
            var results = Analyze(teams, [candidate]);

            // If there was a max, trim the list before doing the lookup
            if (max.HasValue)
            { 
                results = results.Take(max.Value);
            }

            // Look through the results and get the desired data for the result set.
            foreach (var result in results)
            {
                // TBD: Need DL operation to get TeamProfile by Id (something we have in the results)
                //var team = await _dataLayer.GetTeamProfile(result.Team.mana);

                summaries.Add(new TeamAnalysisSummary()
                {
                    TeamName = "Team Record Missing",
                    TeamId = result.Team.TeamId,
                    Score = result.Score
                });
            }

            return summaries;
        }

        public async Task<IEnumerable<CandidateAnalysisSummary>> MatchTeamWithCandidates(int teamId, int? max)
        {
            var summaries = new List<CandidateAnalysisSummary>();

            var team = new TeamWithSkills()
            {
                TeamId = teamId,
                Skills = await _dataLayer.GetTeamSkills(teamId)
            };

            var candidates = await _dataLayer.GetAllCandidatesWithSkills();

            // Do analysis
            var results = Analyze([team], candidates);

            // If there was a max, trim the list before doing the lookup
            if (max.HasValue)
            {
                results = results.Take(max.Value);
            }

            // Look through the results and get the desired data for the result set.
            foreach (var result in results)
            {
                var candidate = await _dataLayer.GetCandidateProfile(result.Candidate.CandidateId);

                summaries.Add(new CandidateAnalysisSummary()
                {
                    CandidateName = candidate != null ? $"{candidate?.FirstName} {candidate?.LastName}" : "Candidate Record Missing",
                    CandidateId = result.Candidate.CandidateId,
                    Score = result.Score
                });
            }

            return summaries;
        }

    }

}
