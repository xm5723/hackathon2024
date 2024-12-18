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
        public static string connString = "Server=tcp:mtbhackathon2024.database.windows.net,1433;Initial Catalog=FitIn;Persist Security Info=False;User ID=fitinadmin;Password=Hackathon2024;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;";

        private readonly ILogger<CandidateController> _logger;

        public CandidateController(ILogger<CandidateController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetAllProfiles")]
        public IEnumerable<CandidateProfile> GetAllProfiles()
        {
            var profiles = new List<CandidateProfile>();

            using var conn = new SqlConnection(connString);
            conn.Open();

            var command = new SqlCommand("SELECT * FROM CandidateProfile", conn);
            using SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    profiles.Add(new CandidateProfile
                    {
                        Id = reader.GetString(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Email = reader.GetString(3),
                        Education = reader.GetString(4),
                        YearOfGradution = reader.GetString(5),
                        FunFact = reader.GetString(6)
                    });
                }
            }
            conn.Close();
            return profiles;
        }

        [HttpGet("GetProfileById/{id}")]
        public async Task<CandidateProfile> GetProfileById(string id)
        {
            var candidateProfile = new CandidateProfile();

            using var conn = new SqlConnection(connString);
            conn.Open();

            var command = new SqlCommand("SELECT * FROM CandidateProfile WHERE uid = @Id", conn);
            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar) { Value = id });
            using SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    candidateProfile = new CandidateProfile
                    {
                        Id = reader.GetString(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Email = reader.GetString(3),
                        Education = reader.GetString(4),
                        YearOfGradution = reader.GetString(5),
                        FunFact = reader.GetString(6)
                    };
                }
            }
            conn.Close();
            return candidateProfile;
        }

        [HttpGet("GetSkillsById/{id}")]
        public async Task<IEnumerable<CandidateSkill>> GetSkillsById(string id)
        {
            var candidateSkills = new List<CandidateSkill>();

            using var conn = new SqlConnection(connString);
            conn.Open();

            var command = new SqlCommand("SELECT * FROM CandidateSkill WHERE candidate_id = @Id", conn);
            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar) { Value = id });
            using SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    candidateSkills.Add(new CandidateSkill
                    {
                        CandidateId = reader.GetString(0),
                        SkillId = reader.GetInt32(1),
                        SkillLevel = reader.GetString(2)

                    });
                }
            }
            conn.Close();
            return candidateSkills;
        }
    }
}

