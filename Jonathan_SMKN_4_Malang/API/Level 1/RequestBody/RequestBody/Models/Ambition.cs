using System.Text.Json.Serialization;

namespace RequestBody.Models
{
    public class Ambition
    {
        
        [JsonPropertyName("nama")]
        public string FullName { get; set; }

        [JsonPropertyName("cita_cita")]
        public string CitaCita { get; set; }
    }
}
