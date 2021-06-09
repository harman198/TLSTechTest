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

        public Job GetJob(int id)
        {
            return _repository.GetJob(id);
        }
    }
}
