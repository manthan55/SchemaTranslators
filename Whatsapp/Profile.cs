using Newtonsoft.Json;

namespace Whatsapp
{
    public class Profile
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; } = string.Empty;
    }
}
