using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLSJobs.Api.Dtos;
using TLSJobs.Api.Models;

namespace TLSJobs.Api
{
    public static class Extensions
    {
        public static JobDto toDto(this Job job)
        {
            return new JobDto() { 
                Id = job.Id,
                Title = job.Title,
                Salary = job.Salary,
                Description = job.Description,
                Type = Enum.GetName(job.Type),
                AddedAt = job.AddedAt
            };
        }
    }
}
