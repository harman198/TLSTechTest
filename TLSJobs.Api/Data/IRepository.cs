using System.Collections.Generic;
using TLSJobs.Api.Models;

namespace TLSJobs.Api.Data
{
    public interface IRepository
    {
        IEnumerable<Job> GetJobs();
    }
}