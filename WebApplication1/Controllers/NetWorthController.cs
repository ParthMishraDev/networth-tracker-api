using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetworkTracker.Core;
using System;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NetWorthController : ControllerBase
    {
        private readonly ILogger<NetWorthController> _logger;
        private readonly INetWorthRepository _netWorthRepository;

        public NetWorthController(ILogger<NetWorthController> logger, INetWorthRepository netWorthRepository)
        {
            _logger = logger;
            _netWorthRepository = netWorthRepository;
        }

        [HttpGet]
        public NetWorth Get()
        {
            var netWorth = _netWorthRepository.GetNetWorthById(0);
            return netWorth;
        }

        [HttpPut]
        public NetWorth Put(NetWorth netWorth)
        {
            _netWorthRepository.UpdateNetWorth(netWorth);
            var result = _netWorthRepository.GetNetWorthById(netWorth.Id);
            return result;
        }
    }
}
