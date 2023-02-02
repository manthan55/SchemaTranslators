using Newtonsoft.Json;

namespace Whatsapp
{
    public class Metadata
    {
        [JsonProperty("display_phone_number", Required = Required.Always)]
        public string DisplayPhoneNumber { get; set; } = string.Empty;

        [JsonProperty("phone_number_id", Required = Required.Always)]
        public string PhoneNumberId { get; set; } = string.Empty;
    }
}
