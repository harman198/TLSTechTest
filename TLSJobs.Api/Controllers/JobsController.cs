using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TLSJobs.Api.Data;
using TLSJobs.Api.Models;

namespace TLSJobs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private IRepository _repository;

        public JobsController(IRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public IEnumerable<Job> GetJobs()
        {
            return _repository.GetJobs();
        }

        [HttpGet("{id}")]
        public ActionResult<Job> GetJob(int id)
        {
            Job job = _repository.GetJob(id);

            if (job is null) return NotFound();

            return job;
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteJob(int id)
        {
            var job = _repository.GetJob(id);

            if (job is null) return NotFound();

            return NoContent();
        }
    }
}
