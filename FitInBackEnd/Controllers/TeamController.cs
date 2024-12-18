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
        public async Task<IEnumerable<AnalysisResult>> FindCandidatesById(string id)
        {
            var candidates = new List<AnalysisResult>
            {
                new AnalysisResult()
                {
                    CandidateId = Guid.NewGuid().ToString(),
                    TeamId = id,
                    Score = 27
                },
                new AnalysisResult()
                {
                    CandidateId = Guid.NewGuid().ToString(),
                    TeamId = id,
                    Score = 24
                },
                new AnalysisResult()
                {
                    CandidateId = Guid.NewGuid().ToString(),
                    TeamId = id,
                    Score = 21
                }
            };
            return candidates;
        }
    }
}

