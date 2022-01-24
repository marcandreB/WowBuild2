using Microsoft.AspNetCore.Mvc;
using Test_API.Domain;

namespace Test_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DickController : ControllerBase
    {
        private readonly ILogger<DickController> _logger;
        private Dick dick = new Dick();
        public DickController(ILogger<DickController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetDick")]
        public string Get()
        {
            return $@"{TokenPriceController.GetTokenPrice()}
                " + dick.GetDickString();
        }

    }
}
