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
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnAddIfJobIsInvalidAndLogItAsync(
            string invalidText)
        {
            //given
            var invalidJob = new Jobs
            {
                Title = invalidText,
            };

            var invalidJobException = new InvalidJobException();

            invalidJobException.AddData(
                key: nameof(Jobs.Id),
                values: "Id is required");

            invalidJobException.AddData(
                key: nameof(Jobs.Title),
                values: "Title is required");

            invalidJobException.AddData(
                key: nameof(Jobs.CreatedDate),
                values: "Date is required");

            invalidJobException.AddData(
                key: nameof(Jobs.UpdatedDate),
                values: "Date is required");

            var expectedJobValidationException =
                new JobValidationException(invalidJobException);

            //when
            ValueTask<Jobs> addJobTask = this.jobService.AddJobAsync(invalidJob);

            JobValidationException actualJobValidationException = 
                await Assert.ThrowsAsync<JobValidationException>(addJobTask.AsTask);

            //then
            actualJobValidationException.Should().BeEquivalentTo(expectedJobValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedJobValidationException))),
                        Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertJobAsync(It.IsAny<Jobs>()), Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
