using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using TLSJobs.Api.Controllers;
using TLSJobs.Api.Data;
using TLSJobs.Api.Models;
using Xunit;

namespace TLSJobs.Api.Tests.Controllers
{
    public class JobsControllerTests
    {

        private readonly Job job1 = new Job() { Id = 1, Title = "Front End Developer", Description = "Expert Front End Developer needed for startup.", Type = JobType.frontend, Salary = 80000, AddedAt = DateTime.Now };
        private readonly Job job2 = new Job() { Id = 2, Title = "Back End Developer", Description = "Expert Back End Developer needed for startup.", Type = JobType.frontend, Salary = 80000, AddedAt = DateTime.Now };
        private readonly Job job3 = new Job() { Id = 3, Title = "Full Stack Developer", Description = "Expert Full Stack Developer needed for startup.", Type = JobType.frontend, Salary = 80000, AddedAt = DateTime.Now };

        private readonly Mock<IRepository> repository = new Mock<IRepository>();

        [Fact]
        public void GetJobs_ShouldReturnEmpty_WhenNoJobsAvailable()
        {
            var expectedResult = new List<Job>();
            repository.Setup(x => x.GetJobs()).Returns(expectedResult);

            var controller = new JobsController(repository.Object);

            var actualResult = controller.GetJobs();

            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void GetJobs_ShouldReturnExpectedItems_WhenJobsAreAvailable()
        {
            var expectedResult = new List<Job>() { job1, job2, job3 };
            repository.Setup(x => x.GetJobs()).Returns(expectedResult);

            var controller = new JobsController(repository.Object);

            var actualResult = controller.GetJobs();

            actualResult.Should().BeEquivalentTo(expectedResult);

        }

        [Fact]
        public void GetJob_ShouldReturnExpectedJob_WhenJobIsFound()
        {
            const int IdToSearch = 1;

            repository.Setup(x => x.GetJob(IdToSearch)).Returns(job1);

            var controller = new JobsController(repository.Object);

            var actualResult = controller.GetJob(IdToSearch);

            actualResult.Result.Should().BeNull();
            actualResult.Value.Should().BeEquivalentTo(job1);
        }

        [Fact]
        public void GetJob_ShouldReturnNotFound_WhenJobIsNotFound()
        {
            const int IdToSearch = 1;

            repository.Setup(x => x.GetJob(IdToSearch)).Returns((Job)null);

            var controller = new JobsController(repository.Object);

            var actualResult = controller.GetJob(IdToSearch);

            actualResult.Result.Should().BeOfType<NotFoundResult>();
            actualResult.Value.Should().BeNull();
        }


        [Fact]
        public void DeleteJob_ShouldReturnNoContent_WhenJobIsPresentInRepository()
        {
            const int IdToSearch = 1;

            repository.Setup(x => x.GetJob(IdToSearch)).Returns(job1);

            var controller = new JobsController(repository.Object);

            var actualResult = controller.DeleteJob(IdToSearch);

            actualResult.Should().BeOfType<NoContentResult>();
        }


        [Fact]
        public void DeleteJob_ShouldReturnNotFound_WhenJobIsPresentInRepository()
        {
            const int IdToSearch = 1;

            repository.Setup(x => x.GetJob(IdToSearch)).Returns((Job)null);

            var controller = new JobsController(repository.Object);

            var actualResult = controller.DeleteJob(IdToSearch);

            actualResult.Should().BeOfType<NotFoundResult>();
        }

    }
}
