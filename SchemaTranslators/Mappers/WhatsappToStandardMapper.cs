using Standard.Common;
using Whatsapp;

namespace SchemaTranslators.Mappers
{
    public class WhatsappToStandardMapper : AutoMapper.Profile
    {
        public WhatsappToStandardMapper()
        {
            // Domain.User ---> Entity.User
            CreateMap<Body, Message<Standard.MessageModels.Text>>()
                    .ForMember(
                            dest => dest.MessagingProduct,
                            opt => opt.MapFrom(
                                        src => MapMessagingProduct(src.Entries[0].Changes[0].Value.MessagingProduct))
                        )
                    .ForMember(
                            dest => dest.Id,
                            opt => opt.MapFrom(
                                        src => src.Entries[0].Changes[0].Value.Messages[0].Id
                                    )
                        )
                    .ForMember(
                            dest => dest.MessageType,
                            opt => opt.MapFrom(
                                        src => MapMessageType(src.Entries[0].Changes[0].Value.Messages[0].Type)
                                    )
                        )
                    .ForMember(
                            dest => dest.DateTime,
                            opt => opt.MapFrom(
                                        src => TimestampToDate(src.Entries[0].Changes[0].Value.Messages[0].Timestamp)
                                    )
                        )
                    .ForMember(
                            dest => dest.From,
                            opt => opt.MapFrom(
                                        src => src.Entries[0].Changes[0].Value.Messages[0].From
                                    )
                        )
                    .ForMember(
                            dest => dest.MessageData,
                            opt => opt.MapFrom(
                                        src => new Standard.MessageModels.Text(src.Entries[0].Changes[0].Value.Messages[0].Text.Body)
                                    )
                        );
        }

        // deprecated ans
        // https://stackoverflow.com/a/28857694
        // new ans
        // https://stackoverflow.com/a/53647743
        static MessagingProduct MapMessagingProduct(string value)
        {
            switch (value)
            {
                case "whatsapp":
                    return MessagingProduct.WHATSAPP;
                default:
                    return MessagingProduct.OTHER;
            }
        }

        static MessageType MapMessageType(string value)
        {
            switch (value)
            {
                case "whatsapp":
                    return MessageType.TEXT;
                default:
                    return MessageType.UNDEFINED;
            }
        }

        static DateTime TimestampToDate(string timestamp)
        {
            int ts = Convert.ToInt32(timestamp);
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(ts).ToLocalTime();
        }
    }
}
