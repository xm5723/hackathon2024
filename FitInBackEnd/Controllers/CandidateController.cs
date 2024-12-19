using Hackathon2024.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Hackathon2024.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly DataLayer _dataLayer;
        private readonly BusinessLogic _businessLogic;
        private readonly ILogger<CandidateController> _logger;

        public CandidateController(DataLayer dataLayer, BusinessLogic businessLogic, ILogger<CandidateController> logger)
        {
            _dataLayer = dataLayer;
            _businessLogic = businessLogic;
            _logger = logger;
        }

        [HttpGet("GetAllProfiles")]
        public async Task<IEnumerable<CandidateProfile>> GetAllProfiles()
        {
            return await _dataLayer.GetAllCandidateProfiles();
        }

        [HttpGet("GetProfileById/{id}")]
        public async Task<CandidateProfile> GetProfileById(string id)
        {
            return await _dataLayer.GetCandidateProfile(id);
        }

        [HttpGet("GetSkillsById/{id}")]
        public async Task<IEnumerable<CandidateSkill>> GetSkillsById(string id)
        {
            return await _dataLayer.GetCandidateSkills(id);
        }

        [HttpGet("FindTeamsById/{id}")]
        public async Task<IEnumerable<TeamAnalysisSummary>> FindTeamsById(string id, int? maxTeams = 10)
        {
            return await _businessLogic.MatchCandidateWithTeams(id, maxTeams);
        }

    }
}

