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
        public static string connString = "Server=tcp:mtbhackathon2024.database.windows.net,1433;Initial Catalog=FitIn;Persist Security Info=False;User ID=fitinadmin;Password=Hackathon2024;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;";

        private readonly ILogger<TeamController> _logger;

        public TeamController(ILogger<TeamController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetAllProfiles")]
        public IEnumerable<TeamProfile> GetAllProfile()
        {
            var profiles = new List<TeamProfile>();

            using var conn = new SqlConnection(connString);
            conn.Open();

            var command = new SqlCommand("SELECT * FROM Teams", conn);
            using SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    profiles.Add(new TeamProfile
                    {
                        Id = reader.GetInt32(0),
                        TeamName = reader.GetString(1),
                        ManagerUId = reader.GetString(2),
                        TeamLocation = reader.GetString(3),
                        TeamMembers = reader.GetString(4),
                        Projects = reader.GetString(5),
                        Organization = reader.GetString(6),
                        NetPromoterScore = reader.GetDecimal(7)
                    });
                }
            }
            conn.Close();
            return profiles;
        }

        [HttpGet("GetProfileById/{id}")]
        public async Task<TeamProfile> GetProfileById(string id)
        {
            var teamProfile = new TeamProfile();

            using var conn = new SqlConnection(connString);
            conn.Open();

            var command = new SqlCommand("SELECT * FROM Teams WHERE id = @Id", conn);
            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar) { Value = id });
            using SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    teamProfile = new TeamProfile
                    {
                        Id = reader.GetInt32(0),
                        TeamName = reader.GetString(1),
                        ManagerUId = reader.GetString(2),
                        TeamLocation = reader.GetString(3),
                        TeamMembers = reader.GetString(4),
                        Projects = reader.GetString(5),
                        Organization = reader.GetString(6),
                        NetPromoterScore = reader.GetDecimal(7)
                    };
                }
            }
            conn.Close();
            return teamProfile;
        }

        [HttpGet("GetSkillsById/{id}")]
        public async Task<IEnumerable<TeamSkill>> GetSkillsById(string id)
        {
            var teamSkills = new List<TeamSkill>();

            using var conn = new SqlConnection(connString);
            conn.Open();

            var command = new SqlCommand("SELECT * FROM TeamSkill WHERE team_id = @Id", conn);
            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar) { Value = id });
            using SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    teamSkills.Add(new TeamSkill
                    {
                        TeamId = reader.GetInt32(0),
                        SkillId = reader.GetInt32(1),
                        SkillLevel = reader.GetString(2)

                    });
                }
            }
            conn.Close();
            return teamSkills;
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

