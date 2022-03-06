using BackgroundServiceSample.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundServiceSample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MyController : ControllerBase
    {

        private readonly ITaskJob _taskJob;

        public MyController(ITaskJob taskJob)
        {
            _taskJob = taskJob;
        }

        [HttpPost]
        public IActionResult Send([FromBody]Message message)
        {
            _taskJob.Queue.Enqueue(message.Text);
            return Ok();
        }
    }
}
