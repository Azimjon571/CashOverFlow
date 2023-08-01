//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System.Threading.Tasks;
using CashOverFlow.Models.Job.Exceptions;
using CashOverFlow.Models.Jobs;
using FluentAssertions;
using Moq;
using Xunit;

namespace CashOverFlow.Tests.Unit.Services.Foundations.Job
{
    public partial class JobServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfJobInpulIsNullAndLogItAsync()
        {
            //given
            Jobs nulljob = null;
            var nullJobException = new NullJobException();

            var expectedJobValidationException =
                new JobValidationException(nullJobException);

            //when
            ValueTask<Jobs> addJobTask =
                this.jobService.AddJobAsync(nulljob);

            JobValidationException actualJobValidationException =
                await Assert.ThrowsAsync<JobValidationException>(addJobTask.AsTask);
            //then
            actualJobValidationException.Should().BeEquivalentTo(expectedJobValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedJobValidationException))),
                        Times.Once);

            this.storageBrokerMock.Verify(broker=>
                broker.InsertJobAsync(It.IsAny<Jobs>()),
                    Times.Never);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
