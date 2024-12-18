using System.Text.Json.Serialization;

namespace Hackathon2024.Objects
{
    public class TeamProfile
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("team_name")]
        public string TeamName { get; set; }

        [JsonPropertyName("manager_uid")]
        public string ManagerUId { get; set; }

        [JsonPropertyName("team_location")]
        public string TeamLocation { get; set; }

        [JsonPropertyName("team_members")]
        public string TeamMembers { get; set; }

        [JsonPropertyName("projects")]
        public string Projects { get; set; }

        [JsonPropertyName("organization")]
        public string Organization { get; set; }

        [JsonPropertyName("net_promoter_score")]
        public decimal NetPromoterScore { get; set; }
    }
}
