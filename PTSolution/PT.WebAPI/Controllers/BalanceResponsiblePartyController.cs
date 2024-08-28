using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PT.BLL.Dto;
using PT.BLL.Interfaces;
using PT.WebAPI.Helpers;

namespace PT.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/balance-responsible-party")]
    [ApiController]
    public class BalanceResponsiblePartyController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IBalanceResponsibleParty _repository;
        private readonly ILogger<BalanceResponsiblePartyController> _logger;


        public BalanceResponsiblePartyController(IConfiguration configuration, IBalanceResponsibleParty repository, ILogger<BalanceResponsiblePartyController> logger)
        {
            _configuration = configuration;
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(BalanceResponsiblePartyDto[]), 200)]
        public IActionResult Get()
        {
            _logger.LogInformation("GET api/balance-responsible-party");

            return Ok(_repository.Get());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="country"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <exception cref="BadHttpRequestException"></exception>
        [HttpGet("{country}/{code}")]
        [ProducesResponseType(typeof(BalanceResponsiblePartyDto), 200)]
        public IActionResult Get([FromRoute] string country, [FromRoute] string code)
        {
            _logger.LogInformation($"GET api/balance-responsible-party/{country}/{code}");

            if (!_repository.Exists(country, code)) throw new BadHttpRequestException($"There isn't an item with the code {code} for the country {country}");

            return Ok(_repository.Get(country, code));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="BadHttpRequestException"></exception>
        [HttpPost("initialization")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Post()
        {
            _logger.LogInformation($"POST api/balance-responsible-party/initialization");

            if (string.IsNullOrWhiteSpace(_configuration.GetConnectionString("ExternalServiceURL"))) throw new BadHttpRequestException("The URL of the external service is required to perform the initial load");

            if (_repository.IsEmpty())
            {
                var data = ExternalService.GetData(_configuration.GetConnectionString("ExternalServiceURL"));

                _repository.Load(data);

                return Ok(true);
            }

            return Ok(false);
        }
    }
}
