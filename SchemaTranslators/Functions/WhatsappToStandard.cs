using AutoMapper;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SchemaTranslators.APIResponseModels;
using SchemaTranslators.Models;
using Standard.Common;
using Standard.MessageModels;

namespace SchemaTranslators.Functions
{
    public class WhatsappToStandard
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public WhatsappToStandard(ILoggerFactory loggerFactory, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<WhatsappToStandard>();
            _mapper = mapper;
        }

        [Function("WhatsappToStandard")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            InvocationDetails invocationDetails = new(req.FunctionContext.InvocationId, req.FunctionContext.FunctionId);
            Whatsapp.Body? body;
            HttpResponseData response = req.CreateResponse();

            try
            {
                #region Reading & converting JSON input to model
                _logger.LogInformation("Reading & converting JSON input to model");
                body = await req.ReadFromJsonAsync<Whatsapp.Body>();
                _logger.LogInformation(JsonConvert.SerializeObject(body));
                #endregion

                #region Automap models
                Message<Text> message = _mapper.Map<Message<Text>>(body);
                #endregion

                #region Send Response
                Response<Whatsapp.Body, Message<Text>> successResponse = new Response<Whatsapp.Body, Message<Text>>(
                    success: false,
                    invocationDetails: invocationDetails,
                    input: body,
                    responseData: message
                    );
                await response.WriteAsJsonAsync(successResponse);
                return response;
                #endregion
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                Response<object, Error> errorResponse = new Response<object, Error>(
                    success: false,
                    invocationDetails: invocationDetails,
                    input: "123",
                    responseData: new Error(
                        message: ex.Message,
                        stack: ex.StackTrace,
                        exception: ex.ToString(),
                        innerException: ex.InnerException?.ToString()
                        )
                    );
                await response.WriteAsJsonAsync(errorResponse);
                return response;
            }
            finally
            {

            }



            //var response = req.CreateResponse(HttpStatusCode.OK);
            //await response.WriteAsJsonAsync(invocationDetails);

            //return response;
        }
    }
}
