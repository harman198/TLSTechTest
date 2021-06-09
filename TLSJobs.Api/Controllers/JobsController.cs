using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IEnumerable<Job> GetJobs()
        {
            return _repository.GetJobs();
        }

        public ActionResult<Job> GetJob(int id)
        {
            Job job = _repository.GetJob(id);

            if (job is null) return NotFound();

            return job;
        }

        public ActionResult DeleteJob(int id)
        {
            return NoContent();
        }
    }
}
