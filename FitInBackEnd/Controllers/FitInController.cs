//using Hackathon2024.Objects;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Data.SqlClient;
//using System.Data;

//namespace Hackathon2024.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class FitInController : ControllerBase
//    {
//        public static string connString = "Server=tcp:mtbhackathon2024.database.windows.net,1433;Initial Catalog=FitIn;Persist Security Info=False;User ID=fitinadmin;Password=Hackathon2024;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;";

//        private readonly ILogger<FitInController> _logger;

//        public FitInController(ILogger<FitInController> logger)
//        {
//            _logger = logger;
//        }

//        [HttpGet("GetAllCandidateProfiles")]
//        public IEnumerable<CandidateProfile> GetAllCandidateProfile()
//        {
//            var profiles = new List<CandidateProfile>();

//            using var conn = new SqlConnection(connString);
//            conn.Open();

//            var command = new SqlCommand("SELECT * FROM CandidateProfile", conn);
//            using SqlDataReader reader = command.ExecuteReader();

//            if (reader.HasRows)
//            {
//                while (reader.Read())
//                {
//                    profiles.Add(new CandidateProfile
//                    {
//                        Id = reader.GetString(0),
//                        FirstName = reader.GetString(1),
//                        LastName = reader.GetString(2),
//                        Email = reader.GetString(3),
//                        Education = reader.GetString(4),
//                        YearOfGradution = reader.GetString(5),
//                        FunFact = reader.GetString(6)
//                    });
//                }
//            }
//            conn.Close();
//            return profiles;
//        }

//        [HttpGet("GetAllTeamProfiles")]
//        public IEnumerable<TeamProfile> GetAllTeamProfile()
//        {
//            var profiles = new List<TeamProfile>();

//            using var conn = new SqlConnection(connString);
//            conn.Open();

//            var command = new SqlCommand("SELECT * FROM Teams", conn);
//            using SqlDataReader reader = command.ExecuteReader();

//            if (reader.HasRows)
//            {
//                while (reader.Read())
//                {
//                    profiles.Add(new TeamProfile
//                    {
//                        Id = reader.GetInt32(0),
//                        TeamName = reader.GetString(1),
//                        ManagerUId = reader.GetString(2),
//                        TeamLocation = reader.GetString(3),
//                        TeamMembers = reader.GetString(4),
//                        Projects = reader.GetString(5),
//                        Organization = reader.GetString(6),
//                        NetPromoterScore = reader.GetDecimal(7)
//                    });
//                }
//            }
//            conn.Close();
//            return profiles;
//        }

//        [HttpGet("GetProfileTypeById/{id}")]
//        public async Task<string> GetProfileTypeById(string id)
//        {
//            var profileType = "";
//            using (var conn = new SqlConnection(connString))
//            {
//                await conn.OpenAsync();
//                var candidateCommand = new SqlCommand("SELECT * FROM CandidateProfile WHERE uid = @Id", conn);
//                // Add the parameter to the SQL query
//                candidateCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar) { Value = id });
//                using SqlDataReader candidateReader = candidateCommand.ExecuteReader();
//                if (candidateReader.HasRows)
//                {
//                    profileType = "Candidate";
//                    conn.Close();
//                }
//                else
//                {
//                    conn.Open();
//                    var managerCommand = new SqlCommand("SELECT * FROM Managers WHERE uid = @Id", conn);
//                    managerCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar) { Value = id });
//                    using SqlDataReader managerReader = managerCommand.ExecuteReader();

//                    if (managerReader.HasRows)
//                    {
//                        profileType = "Manager";
//                    }
//                    else
//                    {
//                        return ""; // if no profile is found with that ID
//                    }
//                }
//                conn.Close();
//                return profileType;
//            }
//        }

//        [HttpGet("GetTeamProfileById/{id}")]
//        public async Task<TeamProfile> GetTeamProfileById(string id)
//        {
//            var teamProfile = new TeamProfile();

//            using var conn = new SqlConnection(connString);
//            conn.Open();

//            var command = new SqlCommand("SELECT * FROM Teams WHERE id = @Id", conn);
//            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar) { Value = id });
//            using SqlDataReader reader = command.ExecuteReader();

//            if (reader.HasRows)
//            {
//                while (reader.Read())
//                {
//                    teamProfile = new TeamProfile
//                    {
//                        Id = reader.GetInt32(0),
//                        TeamName = reader.GetString(1),
//                        ManagerUId = reader.GetString(2),
//                        TeamLocation = reader.GetString(3),
//                        TeamMembers = reader.GetString(4),
//                        Projects = reader.GetString(5),
//                        Organization = reader.GetString(6),
//                        NetPromoterScore = reader.GetDecimal(7)
//                    };
//                }
//            }
//            conn.Close();
//            return teamProfile;
//        }

//        [HttpGet("GetCandidateProfileById/{id}")]
//        public async Task<CandidateProfile> GetCandidateProfileById(string id)
//        {
//            var candidateProfile = new CandidateProfile();

//            using var conn = new SqlConnection(connString);
//            conn.Open();

//            var command = new SqlCommand("SELECT * FROM CandidateProfile WHERE uid = @Id", conn);
//            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar) { Value = id });
//            using SqlDataReader reader = command.ExecuteReader();

//            if (reader.HasRows)
//            {
//                while (reader.Read())
//                {
//                    candidateProfile = new CandidateProfile
//                    {
//                        Id = reader.GetString(0),
//                        FirstName = reader.GetString(1),
//                        LastName = reader.GetString(2),
//                        Email = reader.GetString(3),
//                        Education = reader.GetString(4),
//                        YearOfGradution = reader.GetString(5),
//                        FunFact = reader.GetString(6)
//                    };
//                }
//            }
//            conn.Close();
//            return candidateProfile;
//        }

//        [HttpGet("GetTeamSkillsByTeamId/{id}")]
//        public async Task<IEnumerable<TeamSkill>> GetTeamSkillsByTeamId(string id)
//        {
//            var teamSkills = new List<TeamSkill>();

//            using var conn = new SqlConnection(connString);
//            conn.Open();

//            var command = new SqlCommand("SELECT * FROM TeamSkill WHERE team_id = @Id", conn);
//            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar) { Value = id });
//            using SqlDataReader reader = command.ExecuteReader();

//            if (reader.HasRows)
//            {
//                while (reader.Read())
//                {
//                    teamSkills.Add(new TeamSkill
//                    {
//                        TeamId = reader.GetInt32(0),
//                        SkillId = reader.GetInt32(1),
//                        SkillLevel = reader.GetString(2)

//                    });
//                }
//            }
//            conn.Close();
//            return teamSkills;
//        }

//        [HttpGet("GetCandidateSkillsByTeamId/{id}")]
//        public async Task<IEnumerable<CandidateSkill>> GetCandidateSkillsByTeamId(string id)
//        {
//            var candidateSkills = new List<CandidateSkill>();

//            using var conn = new SqlConnection(connString);
//            conn.Open();

//            var command = new SqlCommand("SELECT * FROM CandidateSkill WHERE candidate_id = @Id", conn);
//            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar) { Value = id });
//            using SqlDataReader reader = command.ExecuteReader();

//            if (reader.HasRows)
//            {
//                while (reader.Read())
//                {
//                    candidateSkills.Add(new CandidateSkill
//                    {
//                        CandidateId = reader.GetString(0),
//                        SkillId = reader.GetInt32(1),
//                        SkillLevel = reader.GetString(2)

//                    });
//                }
//            }
//            conn.Close();
//            return candidateSkills;
//        }

//        //[HttpGet("GetBestCandidateByTeamId/{id}")]
//        //public async Task<IEnumerable<CandidateProfile>> GetBestCandidateByTeamId(string id)
//        //{
//        //    var candidateProfiles = new List<CandidateProfile>();

//        //    using var conn = new SqlConnection(connString);
//        //    conn.Open();

//        //    var command = new SqlCommand("SELECT * FROM TeamSkills WHERE id = @Id", conn);
//        //    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar) { Value = id });
//        //    using SqlDataReader reader = command.ExecuteReader();

//        //    if (reader.HasRows)
//        //    {
//        //        while (reader.Read())
//        //        {
//        //            candidateProfiles.Add(new CandidateProfile
//        //            {
//        //                Id = reader.GetString(0),
//        //                FirstName = reader.GetString(1),
//        //                LastName = reader.GetString(2),
//        //                Email = reader.GetString(3),
//        //                Education = reader.GetString(4),
//        //                YearOfGradution = reader.GetString(5),
//        //                FunFact = reader.GetString(6)

//        //            });
//        //        }
//        //    }
//        //    conn.Close();
//        //    return candidateProfiles;
//        //}
//    }

//}

