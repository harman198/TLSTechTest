using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLSJobs.Api.Models;

namespace TLSJobs.Api.Data
{
    public class JobsContext : DbContext
    {

        public JobsContext(DbContextOptions<JobsContext> options) : base(options)
        {

        }

        public DbSet<Job> Jobs { get; set; }

    }
}
