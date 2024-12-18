using Hackathon2024.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Hackathon2024.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        public static string connString = "Server=tcp:mtbhackathon2024.database.windows.net,1433;Initial Catalog=FitIn;Persist Security Info=False;User ID=fitinadmin;Password=Hackathon2024;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;";

        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetProfileTypeById/{id}")]
        public async Task<string> GetProfileTypeById(string id)
        {
            var profileType = "";
            using var conn = new SqlConnection(connString);
            conn.Open();
            //using (var conn = new SqlConnection(connString))
            //{
                //await conn.OpenAsync();
                var candidateCommand = new SqlCommand("SELECT * FROM CandidateProfile WHERE uid = @Id", conn);
                // Add the parameter to the SQL query
                candidateCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar) { Value = id });
                using SqlDataReader candidateReader = candidateCommand.ExecuteReader();
                if (candidateReader.HasRows)
                {
                    profileType = "Candidate";
                    //conn.Close();
                }
                else
                {
                    conn.Close();
                    conn.Open();
                    var managerCommand = new SqlCommand("SELECT * FROM Managers WHERE uid = @Id", conn);
                    managerCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar) { Value = id });
                    using SqlDataReader managerReader = managerCommand.ExecuteReader();

                    if (managerReader.HasRows)
                    {
                        profileType = "Manager";
                    }
                    else
                    {
                        return ""; // if no profile is found with that ID
                    }
                }
                conn.Close();
                return profileType;
            //}
        }
    }
}

