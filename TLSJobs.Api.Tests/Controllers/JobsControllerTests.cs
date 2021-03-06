using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using TLSJobs.Api.Controllers;
using TLSJobs.Api.Data;
using TLSJobs.Api.Dtos;
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

        private const int IdToSearch = 1;

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
            var jobs = new List<Job>() { job1, job2, job3 };
            repository.Setup(x => x.GetJobs()).Returns(jobs);
            var expectedResult = jobs.Select(x => x.toDto());

            var controller = new JobsController(repository.Object);

            var actualResult = controller.GetJobs();

            actualResult.Should().BeEquivalentTo(expectedResult);

        }

        [Fact]
        public void GetJob_ShouldReturnExpectedJob_WhenJobIsFound()
        {
            repository.Setup(x => x.GetJob(IdToSearch)).Returns(job1);

            var controller = new JobsController(repository.Object);

            var actualResult = controller.GetJob(IdToSearch);

            actualResult.Result.Should().BeNull();
            actualResult.Value.Should().BeEquivalentTo(job1.toDto());
        }

        [Fact]
        public void GetJob_ShouldReturnNotFound_WhenJobIsNotFound()
        {
            repository.Setup(x => x.GetJob(IdToSearch)).Returns((Job)null);

            var controller = new JobsController(repository.Object);

            var actualResult = controller.GetJob(IdToSearch);

            actualResult.Result.Should().BeOfType<NotFoundResult>();
            actualResult.Value.Should().BeNull();
        }


        [Fact]
        public void DeleteJob_ShouldReturnNoContent_WhenJobIsPresentInRepository()
        {
            repository.Setup(x => x.GetJob(IdToSearch)).Returns(job1);

            var controller = new JobsController(repository.Object);

            var actualResult = controller.DeleteJob(IdToSearch);

            actualResult.Should().BeOfType<NoContentResult>();
        }


        [Fact]
        public void DeleteJob_ShouldReturnNotFound_WhenJobIsNotPresentInRepository()
        {
            repository.Setup(x => x.GetJob(IdToSearch)).Returns((Job)null);

            var controller = new JobsController(repository.Object);

            var actualResult = controller.DeleteJob(IdToSearch);

            actualResult.Should().BeOfType<NotFoundResult>();
        }


        [Fact]
        public void DeleteJob_ShouldRemoveItemFromRepository_WhenJobIsPresentInRepository()
        {
            repository.Setup(x => x.GetJob(IdToSearch)).Returns(job1);

            var controller = new JobsController(repository.Object);

            var actualResult = controller.DeleteJob(IdToSearch);

            actualResult.Should().BeOfType<NoContentResult>();

            repository.Verify(x => x.RemoveJob(IdToSearch), Times.Once);
        }


        [Fact]
        public void AddJob_ShouldReturnBadRequest_WhenSubmittedJobIsInvalid()
        {
            var job = new CreateJobDto();

            var controller = new JobsController(repository.Object);

            var actualResult = controller.CreateJob(job);

            actualResult.Should().BeOfType<BadRequestResult>();
        }


        [Fact]
        public void AddJob_ShouldReturnCreatedAtResult_WhenSubmittedJobIsValid()
        {
            var job = new CreateJobDto() { Title = "title", Description = "description", Salary = 100, Type = JobType.backend.ToString() };

            repository.Setup(x => x.CreateJob(job)).Returns(job1);
            var controller = new JobsController(repository.Object);

            var actualResult = controller.CreateJob(job);

            actualResult.Should().BeOfType<CreatedAtActionResult>();
            actualResult.Should().Equals(job1);
        }

    }
}
