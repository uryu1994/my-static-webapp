using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using my_static_webapp_domain;

namespace my_static_webapp_api
{
    public static class GetWeatherList
    {
        [FunctionName("GetWeatherList")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var responseData = new List<WeatherForecast>
            {
                { new DateTime(2018, 5, 6), 1, "Freezing" },
                { new DateTime(2018, 5, 7), 14, "Bracing" },
                { new DateTime(2018, 5, 8), -13, "Freezing"},
                { new DateTime(2018, 5, 9), -16, "Balmy"},
                { new DateTime(2018, 5, 10), -2, "Chilly" }
            };

            return new OkObjectResult(JsonConvert.SerializeObject(responseData));
        }
    }
}
