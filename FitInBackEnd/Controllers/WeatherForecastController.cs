using Hackathon2024.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Hackathon2024.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public static string connString = "Server=tcp:mtbhackathon2024.database.windows.net,1433;Initial Catalog=FitIn;Persist Security Info=False;User ID=fitinadmin;Password=Hackathon2024;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;";

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet(Name = "GetProfile")]
        public IEnumerable<Profile> GetCandidateProfile()
        {
            var profiles = new List<Profile>();

            using var conn = new SqlConnection(connString);
            conn.Open();

            var command = new SqlCommand("SELECT * FROM CandidateProfile", conn);
            using SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    profiles.Add(new Profile
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Email = reader.GetString(3),
                        Education = reader.GetString(4),
                        YearOfGradution = reader.GetString(5),
                        FunFact = reader.GetString(6)
                    });
                }
            }

            return profiles;

 
        }
    }
}
