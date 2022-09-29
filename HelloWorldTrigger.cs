using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MCT.Functions
{
    public class HelloWorldTrigger
    {
        //atribuut
        [FunctionName("HelloWorldTrigger")] 
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Hello/World/{myname}")] HttpRequest req,
            string myname,
            ILogger log)
        {
            string result = $"Hello {myname}";
            return new OkObjectResult(result);
        }
        
    }
}
