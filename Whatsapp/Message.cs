using Newtonsoft.Json;

namespace Whatsapp
{
    public class Message
    {
        [JsonProperty("from", Required = Required.Always)]
        public string From { get; set; } = string.Empty;

        [JsonProperty("id", Required = Required.Always)]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("timestamp", Required = Required.Always)]
        public string Timestamp { get; set; } = string.Empty;

        [JsonProperty("text", Required = Required.Always)]
        public Text Text { get; set; } = new();

        [JsonProperty("type", Required = Required.Always)]
        public string Type { get; set; } = string.Empty;
    }
}
