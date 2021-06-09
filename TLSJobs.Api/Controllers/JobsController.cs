using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TLSJobs.Api.Data;
using TLSJobs.Api.Dtos;
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
        public IEnumerable<JobDto> GetJobs()
        {
            return _repository.GetJobs().Select(x => x.toDto());
        }

        [HttpGet("{id}")]
        public ActionResult<JobDto> GetJob(int id)
        {
            Job job = _repository.GetJob(id);

            if (job is null) return NotFound();

            return job.toDto();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteJob(int id)
        {
            var job = _repository.GetJob(id);

            if (job is null) return NotFound();

            _repository.RemoveJob(id);
            return NoContent();
        }

        [HttpPost]
        public ActionResult CreateJob(CreateJobDto job)
        {
            return BadRequest();
        }
    }
}
