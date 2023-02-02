using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Worker;
using Newtonsoft.Json.Serialization;
using Azure.Core.Serialization;
using Newtonsoft.Json;

namespace SchemaTranslators
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults((IFunctionsWorkerApplicationBuilder workerApplication) =>
                {
                    workerApplication.UseNewtonsoftJson();
                })

                // not using below as we want to swap the DEFAULT serializer from System.Text.Json to Newtonsoft.Json
                //.ConfigureServices(services =>
                //{
                //    services.Configure<JsonSerializerOptions>(options =>
                //    {
                //        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                //        options.Converters.Add(new JsonStringEnumConverter());
                //    });
                //})
                .ConfigureServices(services =>
                {
                    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
                })
                .Build();

            host.Run();
        }
    }

    internal static class WorkerConfigurationExtensions
    {
        /// <summary>
        /// The functions worker uses the Azure SDK's ObjectSerializer to abstract away all JSON serialization. This allows you to
        /// swap out the default System.Text.Json implementation for the Newtonsoft.Json implementation.
        /// To do so, add the Microsoft.Azure.Core.NewtonsoftJson nuget package and then update the WorkerOptions.Serializer property.
        /// This method updates the Serializer to use Newtonsoft.Json. Call /api/HttpFunction to see the changes.
        /// 
        /// For more info, checkout, 
        /// https://stackoverflow.com/a/68585421
        /// https://github.com/Azure/azure-functions-dotnet-worker/blob/ec518944144a4bccdc5ea1e0695d9d6b582bc084/samples/Configuration/Program.cs
        /// </summary>
        public static IFunctionsWorkerApplicationBuilder UseNewtonsoftJson(this IFunctionsWorkerApplicationBuilder builder)
        {
            builder.Services.Configure<WorkerOptions>(workerOptions =>
            {
                var settings = NewtonsoftJsonObjectSerializer.CreateJsonSerializerSettings();
                settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                // we want the null values to be included in response
                //settings.NullValueHandling = NullValueHandling.Ignore;
                settings.NullValueHandling = NullValueHandling.Include;

                workerOptions.Serializer = new NewtonsoftJsonObjectSerializer(settings);
            });

            return builder;
        }
    }
}
