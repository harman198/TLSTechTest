using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLSJobs.Api.Models;

namespace TLSJobs.Api.Data
{
    public class InMemoryJobsRepository : IRepository
    {

        private readonly Job job1 = new Job() { Id = 1, Title = "Front End Developer", Description = "Expert Front End Developer needed for startup.", Type = JobType.frontend, Salary = 80000, AddedAt = DateTime.Now };
        private readonly Job job2 = new Job() { Id = 2, Title = "Back End Developer", Description = "Expert Back End Developer needed for startup.", Type = JobType.frontend, Salary = 80000, AddedAt = DateTime.Now };
        private readonly Job job3 = new Job() { Id = 3, Title = "Full Stack Developer", Description = "Expert Full Stack Developer needed for startup.", Type = JobType.frontend, Salary = 80000, AddedAt = DateTime.Now };

        private readonly List<Job> jobs;

        public InMemoryJobsRepository()
        {
            jobs = new List<Job>() { job1, job2, job3 };
        }

        public Job GetJob(int id)
        {
            return jobs.FirstOrDefault(job => job.Id == id);
        }

        public IEnumerable<Job> GetJobs()
        {
            return jobs;
        }
    }
}
