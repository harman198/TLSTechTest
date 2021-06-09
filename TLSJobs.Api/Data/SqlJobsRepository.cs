using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLSJobs.Api.Dtos;
using TLSJobs.Api.Models;

namespace TLSJobs.Api.Data
{
    public class SqlJobsRepository : IRepository
    {

        private readonly JobsContext _context;

        public SqlJobsRepository(JobsContext context)
        {
            _context = context;
        }

        public Job CreateJob(CreateJobDto jobdto)
        {
            var job = new Job()
            {
                Title = jobdto.Title,
                Description = jobdto.Description,
                AddedAt = DateTime.Now,
                Salary = jobdto.Salary,
                Type = (JobType)Enum.Parse(typeof(JobType), jobdto.Type)
            };
            _context.Add(job);
            _context.SaveChanges();
            return job;
        }

        public Job GetJob(int id)
        {
            return _context.Jobs.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Job> GetJobs()
        {
            return _context.Jobs;
        }

        public void RemoveJob(int id)
        {
            var job = GetJob(id);
            if (!(job is null))
            {
                _context.Jobs.Remove(job);
                _context.SaveChanges();
            }
        }
    }
}
