using Hackathon2024.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Hackathon2024.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly DataLayer _dataLayer;
        private readonly ILogger<TeamController> _logger;

        public TeamController(ILogger<TeamController> logger, DataLayer dataLayer)
        {
            _dataLayer = dataLayer;
            _logger = logger;
        }

        [HttpGet("GetAllProfiles")]
        public async Task<IEnumerable<TeamProfile>> GetAllProfile()
        {
            return await _dataLayer.GetAllTeamProfiles();
        }

        [HttpGet("GetProfileById/{id}")]
        public async Task<TeamProfile> GetProfileById(string id)
        {
            return await _dataLayer.GetTeamProfile(id);
        }

        [HttpGet("GetSkillsById/{id}")]
        public async Task<IEnumerable<TeamSkill>> GetSkillsById(string id)
        {
            return await _dataLayer.GetTeamSkills(id);
        }

        [HttpGet("FindCandidatesById/{id}")]
        public async Task<IEnumerable<CandidateAnalysisSummary>> FindCandidatesById(string id, int? maxCandidates = 10)
        {
            var summaries = new List<CandidateAnalysisSummary>();

            // Get the skills for this team and create TeamWithSkills.
            var team = new TeamWithSkills() { 
                TeamId = id,
                Skills = await _dataLayer.GetTeamSkills(id)
            };

            // Call DB to get all CandidateWithSkills
            var candidates = await _dataLayer.GetAllCandidatesWithSkills();

            // Do analysis
            var results = BusinessLogic.Analyze([team], candidates);

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

                if (maxCandidates.HasValue && summaries.Count >= maxCandidates.Value)
                {
                    break;
                }
            }

            return summaries;
        }
    }
}

