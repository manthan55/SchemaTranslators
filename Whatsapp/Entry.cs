using Newtonsoft.Json;

namespace Whatsapp
{
    public class Entry
    {
        [JsonProperty("id", Required = Required.Always)]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("changes", Required = Required.Always)]
        public List<Change> Changes { get; set; } = new();
    }
}
