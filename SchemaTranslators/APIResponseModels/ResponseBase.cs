using SchemaTranslators.Models;

namespace SchemaTranslators.APIResponseModels
{
    public class ResponseBase<I>
    {
        public ResponseBase(bool success, InvocationDetails invocationDetails, I? input)
        {
            Success=success;
            InvocationDetails=invocationDetails;
#if (DEBUG)
            Input=input;
#endif
        }

        public bool Success { get; }
        public InvocationDetails InvocationDetails { get; }

        // to check if input was parsed correctly
        // only used in debug mode
#if (DEBUG)
        public I? Input { get; }
#endif
    }
}
