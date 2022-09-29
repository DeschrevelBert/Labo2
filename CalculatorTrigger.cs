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

    public class CalculatorTrigger
    {
        [FunctionName("CalculatorTrigger")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "calculator/{getal1}/{op}/{getal2}")] HttpRequest req,
            int getal1, string op, int getal2,
            ILogger log)
        {
            try
            {
                string result = string.Empty;
                if(op=="+"){
                    result = (getal1 + getal2).ToString();
                }
                else if(op=="-"){
                    result = (getal1 - getal2).ToString();
                }
                else if(op=="*"){
                    result = (getal1 * getal2).ToString();
                }
                if(string.IsNullOrEmpty(result)){
                    return new BadRequestObjectResult("Ongeldige operator");
                }
                CalculationResult calculationresult = new CalculationResult{
                    Operator = op,
                    Result = result
                };
                return new OkObjectResult($"Het resultaat is {result}");
            }
            catch (System.Exception ex)
            {
                log.LogError(ex.Message);
                return new StatusCodeResult(500);
            }
        }
    }
}
