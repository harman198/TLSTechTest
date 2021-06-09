using System.Collections.Generic;
using TLSJobs.Api.Dtos;
using TLSJobs.Api.Models;

namespace TLSJobs.Api.Data
{
    public interface IRepository
    {
        IEnumerable<Job> GetJobs();
        Job GetJob(int id);
        void RemoveJob(int id);
        Job CreateJob(CreateJobDto jobdto);
    }
}