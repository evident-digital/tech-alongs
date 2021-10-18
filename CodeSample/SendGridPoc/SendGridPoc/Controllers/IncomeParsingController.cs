using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using SendGridPoc.Models;
using StrongGrid;
using System;
using System.Collections.Generic;

namespace SendGridPoc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IncomeParsingController : ControllerBase
    {
        private const string _cacheKey = "MessageStorage";
        private readonly ILogger<IncomeParsingController> _logger;
        private readonly IMemoryCache _cache;

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

                List<IncomingMessage> cacheEntry;
                if (!_cache.TryGetValue(_cacheKey, out cacheEntry))
                    cacheEntry = new List<IncomingMessage>();

                var email = new IncomingMessage
                {
                    //Dkim = inboundMail.Dkim,
                    To = inboundMail.To[0].Email.ToString(),
                    //Html = inboundMail.Html,
                    From = inboundMail.From.Email.ToString(),
                    Text = inboundMail.Text,
                    //SenderIp = inboundMail.SenderIp,
                    //Envelope = inboundMail.Envelope.ToString(),
                    Attachments = inboundMail.Attachments.Length,
                    Subject = inboundMail.Subject,
                    //Charsets = inboundMail.Charsets.ToString(),
                    //Spf = inboundMail.Spf,
                };
                cacheEntry.Add(email);

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromDays(365));

                _cache.Set(_cacheKey, cacheEntry, cacheEntryOptions);
                _logger.LogInformation("Received email " + inboundMail.Subject);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                throw ex;
            }
        }
    }
}
