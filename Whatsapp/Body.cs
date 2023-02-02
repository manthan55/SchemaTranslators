using Newtonsoft.Json;

namespace Whatsapp
{
    public class Body
    {

        // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings#nonnullable-reference-not-initialized
        // = string.Empty
        [JsonProperty("object", Required = Required.Always)]
        public string Object { get; set; } = string.Empty;

        [JsonProperty("entry", Required = Required.Always)]
        public List<Entry> Entries { get; set; } = new();
    }
}
