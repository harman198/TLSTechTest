using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLSJobs.Api.Models;

namespace TLSJobs.Api.Dtos
{
    public class JobDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public decimal Salary { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
