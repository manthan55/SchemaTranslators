namespace SchemaTranslators.Models
{
    public class InvocationDetails
    {
        public InvocationDetails(string invocationId, string functionId)
        {
            InvocationId=invocationId;
            FunctionId=functionId;
        }

        public string InvocationId { get; }
        public string FunctionId { get; }
    }
}
