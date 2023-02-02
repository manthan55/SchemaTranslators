using Newtonsoft.Json;

namespace Whatsapp
{
    public class Change
    {
        [JsonProperty("value", Required = Required.Always)]
        public Value Value { get; set; } = new();

        [JsonProperty("field", Required = Required.Always)]
        public string Field { get; set; } = string.Empty;
    }
}
