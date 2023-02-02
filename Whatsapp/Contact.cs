using Newtonsoft.Json;

namespace Whatsapp
{
    public class Contact
    {
        [JsonProperty("profile", Required = Required.Always)]
        public Profile Profile { get; set; } = new();

        [JsonProperty("wa_id", Required = Required.Always)]
        public string WAId { get; set; } = string.Empty;
    }
}
