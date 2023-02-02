using Newtonsoft.Json;

namespace Whatsapp
{
    public class Text
    {
        [JsonProperty("body", Required = Required.Always)]
        public string Body { get; set; } = string.Empty;
    }
}
