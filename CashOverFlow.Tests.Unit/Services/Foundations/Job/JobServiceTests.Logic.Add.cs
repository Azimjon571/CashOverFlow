using System.Threading.Tasks;
using CashOverFlow.Models.Jobs;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Xunit;

namespace CashOverFlow.Tests.Unit.Services.Foundations.Job
{
    public partial class JobServiceTests
    {
        [Fact]
        public async Task ShouldAddJobAsync()
        {
            //given
            Jobs randomJobs = CreateRandomJobs();
            Jobs inputJobs = randomJobs;
            Jobs storageJobs = inputJobs;
            Jobs expectedJobs = storageJobs.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.InsertJobAsync(inputJobs)).ReturnsAsync(storageJobs);


            //when
            Jobs actualJobs = await this.jobService.AddJobAsync(inputJobs);

            //then
            actualJobs.Should().BeEquivalentTo(expectedJobs);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertJobAsync(inputJobs), Times.Once);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
