using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using SendGridPoc.Models;
using StrongGrid;

namespace SendGridPoc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IncomeParsingController : ControllerBase
    {
        private const string _cacheKey = "MessageStorage";
        private readonly IMemoryCache _cache;
        private readonly ILogger<IncomeParsingController> _logger;

        public IncomeParsingController(ILogger<IncomeParsingController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        [HttpGet]
        public IEnumerable<IncomingMessage> Get()
        {
            List<IncomingMessage> cacheEntry;
            if (!_cache.TryGetValue(_cacheKey, out cacheEntry))
                cacheEntry = new List<IncomingMessage>();
            return cacheEntry;
        }

        [HttpPost]
        public void Post()
        {
            try
            {
                var parser = new WebhookParser();
                var inboundMail = parser.ParseInboundEmailWebhook(Request.Body);
                _logger.LogInformation("Received email " + inboundMail.Subject);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                throw;
            }
        }
    }
}