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

        [Fact]
        public void JobsController_ShouldReturnEmpty_WhenNoJobsAvailable()
        {
            var expectedResult = new List<Job>();
            Mock<IRepository> repository  = new Mock<IRepository>();
            repository.Setup(x => x.GetJobs()).Returns(expectedResult);

            var controller = new JobsController(repository.Object);

            var actualResult = controller.GetJobs();

            actualResult.Should().BeEquivalentTo(expectedResult);
        }

    }
}
