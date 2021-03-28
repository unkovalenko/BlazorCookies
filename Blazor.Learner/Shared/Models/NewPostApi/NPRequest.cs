using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace BlazorCookies.Shared.Models
{
    public class NPRequest
    {
        public NPRequest(IConfiguration configuration)
        {
            apiKey = configuration.GetValue<string>("APIKey");
        }

        public string apiKey { get; set; }
        public string modelName { get; set; }
        public string calledMethod { get; set; }
    }
}
