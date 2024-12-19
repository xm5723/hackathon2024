using System.Text.Json.Serialization;

namespace Hackathon2024.Objects
{
    public class TeamSkill
    {
        [JsonPropertyName("team_id")]
        public int TeamId { get; set; }

        [JsonPropertyName("skill_id")]
        public int SkillId { get; set; }

        [JsonPropertyName("skill_name")]
        public string SkillName { get; set; }

        [JsonPropertyName("skill_level")]
        public int SkillLevel { get; set; }
    }
}
