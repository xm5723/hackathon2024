using System.Text.Json.Serialization;

namespace Hackathon2024.Objects
{

    public class CandidateWithSkills
    {
        public string CandidateId { get; set; }
        public IEnumerable<CandidateSkill> Skills { get; set; }
    }

}
