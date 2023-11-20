using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Logging.Core;

namespace Logging.Startup.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly Logging.Core.ILogger<ValuesController> _logger;

        public ValuesController(Logging.Core.ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            _logger.LogInfo("The ValuesController Get method is invoked");

            return Ok(new List<object> { new { Id = 1, TaskTitle = "Task 1", Completed = true },
                new { Id = 1, TaskTitle = "Task 1", Completed = false }});

        }
    }
}
