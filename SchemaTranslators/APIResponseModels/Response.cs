using SchemaTranslators.Models;

namespace SchemaTranslators.APIResponseModels
{
    class Response<I, R> : ResponseBase<I>
    {
        public Response(bool success, InvocationDetails invocationDetails, I? input, R responseData) : base(success, invocationDetails, input)
        {
            ResponseData = responseData;
        }

        public R ResponseData { get; }
    }
}
