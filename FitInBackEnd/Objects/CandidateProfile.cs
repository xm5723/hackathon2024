using System.Text.Json.Serialization;

namespace Hackathon2024.Objects
{
    public class CandidateProfile
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("education")]
        public string Education { get; set; }

        [JsonPropertyName("year_of_gradution")]
        public string YearOfGradution { get; set; }

        [JsonPropertyName("fun_fact")]
        public string FunFact { get; set; }
    }
}
