using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FormApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaveController : ControllerBase
    {
        public SaveController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;

        [HttpPost]
        public async Task<string> PostAsync([FromBody] JsonElement json)
        {
            var index = _configuration["elasticsearch:index"];
            var username = _configuration["elasticsearch:username"];
            var password = _configuration["elasticsearch:password"];
            var cloudId = _configuration["elasticsearch:cloud_id"]; 

            var credentials = new BasicAuthenticationCredentials(username, password);
            
            var pool = new CloudConnectionPool(cloudId, credentials);

            var settings = new ConnectionConfiguration(pool);

            var lowlevelClient = new ElasticLowLevelClient(settings);

            var asyncIndexResponse = await lowlevelClient
                                            .IndexAsync<StringResponse>(index, json.ToString());

            return asyncIndexResponse.Body;
        }
    }

}
