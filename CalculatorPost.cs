using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MCT.Functions.Models;

namespace MCT.Functions
{
    public static class CalculatorPost
    {
        [FunctionName("CalculatorPost")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "calculator")] HttpRequest req,
            ILogger log)
        {
            string body = await new StreamReader(req.Body).ReadToEndAsync();
            CalculationRequest calculationRequest = JsonConvert.DeserializeObject<CalculationRequest>(body);

            CalculationResult result = new CalculationResult();
            if(calculationRequest.Operator == "+"){
                result.Result = (calculationRequest.Getal1 + calculationRequest.Getal2).ToString();
                result.Operator = calculationRequest.Operator;
            }
            return new OkObjectResult(result);
        }
    }
}
