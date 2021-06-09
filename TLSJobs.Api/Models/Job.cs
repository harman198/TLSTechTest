using System;
using System.ComponentModel.DataAnnotations;

namespace TLSJobs.Api.Models
{
    public class Job
    {

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public JobType Type { get; set; }

        public decimal Salary { get; set; }
        public DateTime AddedAt { get; set; }

    }
}