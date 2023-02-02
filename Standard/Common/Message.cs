namespace Standard.Common
{
    public class Message<MT>
    {
        public MessagingProduct MessagingProduct { get; set; } = MessagingProduct.OTHER;
        public string Id { get; set; } = string.Empty;
        public MessageType MessageType { get; set; } = MessageType.UNDEFINED;
        
        // timestamp/datetime when message was received
        public DateTime DateTime { get; set; } = default;
        public string From { get; set; } = string.Empty;
        public MT MessageData { get; set; }
    }
}
