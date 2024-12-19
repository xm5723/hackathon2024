using Hackathon2024.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Hackathon2024
{

    public class DataLayer
    {
        public static string connString = "Server=tcp:mtbhackathon2024.database.windows.net,1433;Initial Catalog=FitIn;Persist Security Info=False;User ID=fitinadmin;Password=Hackathon2024;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;";


        #region "Candidate Operations"

        public async Task<IEnumerable<CandidateProfile>> GetAllCandidateProfiles()
        {
            var profiles = new List<CandidateProfile>();

            using var conn = new SqlConnection(connString);
            conn.Open();

            var command = new SqlCommand("SELECT * FROM CandidateProfile", conn);
            using SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
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
            await conn.CloseAsync();
            return profiles;
        }

        public async Task<CandidateProfile?> GetCandidateProfile(string candidateId)
        {
            CandidateProfile? candidateProfile = null;

            using var conn = new SqlConnection(connString);
            await conn.OpenAsync();

            var command = new SqlCommand("SELECT * FROM CandidateProfile WHERE uid = @Id", conn);
            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar) { Value = candidateId });
            using SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                candidateProfile = new CandidateProfile();
                while (await reader.ReadAsync())
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
            await conn.CloseAsync();
            return candidateProfile;
        }

        public async Task<IEnumerable<CandidateSkill>> GetCandidateSkills(string candidateId)
        {
            var candidateSkills = new List<CandidateSkill>();

            using var conn = new SqlConnection(connString);
            conn.Open();

            var command = new SqlCommand("SELECT * FROM CandidateSkill WHERE candidate_id = @Id", conn);
            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar) { Value = candidateId });
            using SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    candidateSkills.Add(new CandidateSkill
                    {
                        CandidateId = reader.GetString(0),
                        SkillId = reader.GetInt32(1),
                        SkillLevel = reader.GetInt32(2)

                    });
                }
            }
            await conn.CloseAsync();
            return candidateSkills;
        }

        public async Task<IEnumerable<CandidateWithSkills>> GetAllCandidatesWithSkills()
        {
            var candidatesWithSkills = new List<CandidateWithSkills>();

            using var conn = new SqlConnection(connString);
            conn.Open();

            var command = new SqlCommand("SELECT * FROM CandidateSkill order by candidate_id", conn);
            using SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                var candidateSkills = new List<CandidateSkill>();
                while (await reader.ReadAsync())
                {
                    candidateSkills.Add(new CandidateSkill
                    {
                        CandidateId = reader.GetString(0),
                        SkillId = reader.GetInt32(1),
                        SkillLevel = reader.GetInt32(2)

                    });
                }

                candidatesWithSkills = candidateSkills
                    .GroupBy(i => i.CandidateId)
                    .Select(i => new CandidateWithSkills() 
                        { 
                            CandidateId = i.Key,
                            Skills = i
                        }
                    ).ToList();
            }
            await conn.CloseAsync();
            return candidatesWithSkills;
        }

        #endregion


        #region "Team Operations"

        public async Task<IEnumerable<TeamProfile>> GetAllTeamProfiles()
        {
            var profiles = new List<TeamProfile>();

            using var conn = new SqlConnection(connString);
            conn.Open();

            var command = new SqlCommand("SELECT * FROM Teams", conn);
            using SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
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
            await conn.CloseAsync();
            return profiles;
        }

        public async Task<TeamProfile?> GetTeamProfile(string teamId)
        {
            TeamProfile? teamProfile = null;

            using var conn = new SqlConnection(connString);
            await conn.OpenAsync();

            var command = new SqlCommand("SELECT * FROM Teams WHERE id = @Id", conn);
            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar) { Value = teamId });
            using SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                teamProfile = new TeamProfile();

                while (await reader.ReadAsync())
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
            await conn.CloseAsync();
            return teamProfile;
        }

        public async Task<IEnumerable<TeamSkill>> GetTeamSkills(string teamId)
        {
            var teamSkills = new List<TeamSkill>();

            using var conn = new SqlConnection(connString);
            await conn.OpenAsync();

            var command = new SqlCommand("SELECT * FROM TeamSkill WHERE team_id = @Id", conn);
            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar) { Value = teamId });
            using SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    teamSkills.Add(new TeamSkill
                    {
                        TeamId = reader.GetInt32(0),
                        SkillId = reader.GetInt32(1),
                        SkillLevel = reader.GetInt32(2)
                    });
                }
            }
            await conn.CloseAsync();

            return teamSkills;
        }

        #endregion


        #region "Other Operations"

        public async Task<string?> GetProfileType(string teamOrCandidateId)
        {
            var team = await GetTeamProfile(teamOrCandidateId);
            if (team != null)
            {
                return "Manager";
            }
            else
            {
                var candidate = await GetCandidateProfile(teamOrCandidateId);
                if (candidate != null)
                {
                    return "Candidate";
                }
            }

            return null;
        }

        #endregion


    }

}
