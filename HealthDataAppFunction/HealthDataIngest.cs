using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using HealthDataApp.Models;
using HealthDataApp.Data;
using System.Net.Http.Json;
using HealthDataApp.Services.Interface;
using System.Security.AccessControl;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace HealthDataAppFunction
{
    public class HealthDataIngest
    {
        private readonly ILogger _logger;
        private readonly IHealthDataService _healthData;
        private readonly IConfiguration _configuration;

        public HealthDataIngest(ILoggerFactory loggerFactory, IHealthDataService healthDataService, IConfiguration configuration)
        {
            _logger = loggerFactory.CreateLogger<HealthDataIngest>();
            _healthData = healthDataService;
            _configuration = configuration;
        }

        [Function("HealthDataIngest")]
        public async Task<HttpResponseData> RunAsync([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonSerializer.Deserialize<HealthData>(requestBody);

            // Process and store the data in Azure SQL Database
            await SaveAndAnalyzeHealthDataAsync(data);

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteStringAsync("Data processed successfully");
            return response;

        }

        private static async Task SaveAndAnalyzeHealthDataAsync(HealthData data)
        {
            //  connection string from configuration
            string connectionString = _configuration.GetConnectionString("SqlConnectionString");

            using (var context = connectionString())
            {
                context.HealthData.Add(data);
                await context.SaveChangesAsync();
            }

            // Perform analysis
            await AnalyzeHealthDataAsync(data);
        }

        private static async Task AnalyzeHealthDataAsync(HealthData data)
        {
            // Example analysis: Generate alert if heart rate exceeds a threshold
            if (data.HeartRate > 100)
            {
                var alert = new Alert
                {
                    PatientId = data.PatientId,
                    AlertType = "High Heart Rate",
                    Timestamp = DateTime.UtcNow,
                    Description = $"Heart rate exceeded 100 bpm: {data.HeartRate}"
                };

               // database connection
                using (var context = new AppDbContext())
                {
                    context.Alerts.Add(alert);
                    await context.SaveChangesAsync();
                }
            }

        }
    }
}
