using System.Text.Json.Serialization;

namespace Hackathon2024.Objects
{
    public class CandidateSkill
    {
        [JsonPropertyName("candidate_id")]
        public string CandidateId { get; set; }
        [JsonPropertyName("skill_id")]
        public int SkillId { get; set; }
        [JsonPropertyName("skill_level")]
        public String SkillLevel { get; set; }
    }
}
