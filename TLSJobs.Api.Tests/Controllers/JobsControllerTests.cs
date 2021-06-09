using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLSJobs.Api.Controllers;
using TLSJobs.Api.Data;
using TLSJobs.Api.Models;
using Xunit;

namespace TLSJobs.Api.Tests.Controllers
{
    public class JobsControllerTests
    {

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
            var expectedResult = new List<Job>()
            {
                new Job() {Id = 1, Title = "Front End Developer", Description = "Expert Front End Developer needed for startup.", Type = JobType.frontend, Salary = 80000, AddedAt = DateTime.Now},
                new Job() {Id = 2, Title = "Back End Developer", Description = "Expert Back End Developer needed for startup.", Type = JobType.frontend, Salary = 80000, AddedAt = DateTime.Now},
                new Job() {Id = 3, Title = "Full Stack Developer", Description = "Expert Full Stack Developer needed for startup.", Type = JobType.frontend, Salary = 80000, AddedAt = DateTime.Now}
            };
            repository.Setup(x => x.GetJobs()).Returns(expectedResult);

            var controller = new JobsController(repository.Object);

            var actualResult = controller.GetJobs();

            actualResult.Should().BeEquivalentTo(expectedResult);

        }

    }
}
