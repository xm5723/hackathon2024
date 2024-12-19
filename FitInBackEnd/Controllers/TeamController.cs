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
        private readonly BusinessLogic _businessLogic;
        private readonly ILogger<TeamController> _logger;

        public TeamController(ILogger<TeamController> logger, DataLayer dataLayer, BusinessLogic businessLogic)
        {
            _dataLayer = dataLayer;
            _logger = logger;
            _businessLogic = businessLogic;
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
        public async Task<IEnumerable<TeamSkill>> GetSkillsById(int id)
        {
            return await _dataLayer.GetTeamSkills(id);
        }

        [HttpGet("FindCandidatesById/{id}")]
        public async Task<IEnumerable<CandidateAnalysisSummary>> FindCandidatesById(int id, int? maxCandidates = 10)
        {
            return await _businessLogic.MatchTeamWithCandidates(id, maxCandidates);
        }
    }
}

