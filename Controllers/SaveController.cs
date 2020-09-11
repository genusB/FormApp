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
        public SaveController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        private IConfiguration configuration;

        [HttpPost]
        public async Task<string> PostAsync([FromBody] JsonElement json)
        {
            var uri = new Uri(configuration["elasticsearch:url"]);
            var index = configuration["elasticsearch:index"];

            var settings = new ConnectionConfiguration(uri);

            var lowlevelClient = new ElasticLowLevelClient(settings);

            var asyncIndexResponse = await lowlevelClient
                                            .IndexAsync<StringResponse>(index, json.ToString());

            return asyncIndexResponse.Body;
        }
    }

}
