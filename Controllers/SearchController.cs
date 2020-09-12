﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FormApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ElasticClient _elasticClient;
        private readonly ILogger<SearchController> _logger;
        private readonly IConfiguration _configuration;

        public SearchController(ILogger<SearchController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

            var uri = new Uri(_configuration["elasticsearch:url"]);
            var index = _configuration["elasticsearch:index"];
            var settings = new ConnectionSettings(uri).DefaultIndex(index);

            _elasticClient = new ElasticClient(settings);
        }

        [HttpPost]
        public async Task<dynamic> Find([FromBody]string query)
        {

            var response = await _elasticClient.SearchAsync<dynamic>(s => s
                .Query(q => q
                    .QueryString(qs => qs
                        .Query(query)
                    )
                )
            );

            if (!response.IsValid)
            {
                _logger.LogError("Failed to search documents");
                return Ok(new dynamic[] { });
            }

            return Ok(response.Documents);
        }

    }
}
