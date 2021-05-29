using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionApp
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run(
            [BlobTrigger("archivos/{name}", Connection = "AzureWebJobsStorage")]Stream myBlob,
            // si es async la funcion, no se puede un out se debe usar in asynccollector o algo parecido
            [Queue("files-processes", Connection = "AzureWebJobsStorage")] out string queue, 
            string name,
            ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

            queue = $"Prueba {name}";
        }
    }
}
