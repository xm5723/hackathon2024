using System.Text.Json.Serialization;

namespace Hackathon2024.Objects
{

    public class TeamWithSkills
    {
        public int TeamId { get; set; }
        public IEnumerable<TeamSkill> Skills { get; set; }
    }

}
