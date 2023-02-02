using Newtonsoft.Json;

namespace Whatsapp
{
    public class Value
    {
        [JsonProperty("messaging_product", Required = Required.Always)]
        public string MessagingProduct { get; set; } = string.Empty;

        [JsonProperty("metadata", Required = Required.Always)]
        public Metadata Metadata { get; set; } = new();

        [JsonProperty("contacts", Required = Required.Always)]
        public List<Contact> Contacts { get; set; } = new();

        [JsonProperty("messages", Required = Required.Always)]
        public List<Message> Messages { get; set; } = new();
    }
}
