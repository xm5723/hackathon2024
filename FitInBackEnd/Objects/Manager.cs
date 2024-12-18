using System.Text.Json.Serialization;

namespace Hackathon2024.Objects
{
    public class Manager
    {
        [JsonPropertyName("uid")]
        public string UId { get; set; }

        [JsonPropertyName("manager_name")]
        public string ManagerName { get; set; }

        [JsonPropertyName("manager_email")]
        public string ManagerEmail { get; set; }

    }
}
