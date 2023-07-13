//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System.Threading.Tasks;
using CashOverFlow.Models.Locations;
using CashOverFlow.Models.Locations.Exceptions;
using FluentAssertions;
using Moq;
using Xunit;

namespace CashOverFlow.Tests.Unit.Services.Foundations.Locations
{
    public partial class LocationServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfInputIsNullAndLogItAsync()
        {
            //given
            Location nullLocation = null;
            var nulllLocationException = new NullLocationException();
            var expectedLocationValidationException = new LocationValidationException(nulllLocationException);

            //when
            ValueTask<Location> addLocationTask =
                this.locationService.AddLocationAsync(nullLocation);

            LocationValidationException actualLocationValidationException =
             await Assert.ThrowsAsync<LocationValidationException>(addLocationTask.AsTask);

            //then
            actualLocationValidationException.Should().BeEquivalentTo(expectedLocationValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExcepionAs(
                    expectedLocationValidationException))), Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertLocationAsync(It.IsAny<Location>()), Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnAddIfLocationIsInvalitAndLogItAsync(
            string invalidText)
        {
            //given
            var invalidLocation = new Location
            {
                Name = invalidText
            };

            var invalidLocationException = new InvalidLocationException();

            invalidLocationException.AddData(
                key: nameof(Location.Id),
                values: "Id is required");

            invalidLocationException.AddData(
                key: nameof(Location.Name),
                values: "Text is required");

            invalidLocationException.AddData(
                key: nameof(Location.CreateDate),
                values: "Date is required");

            invalidLocationException.AddData(
                key: nameof(Location.UpdateDate),
                values: "Date is required");

            var expectedLocationValidationException =
                new LocationValidationException(invalidLocationException);

            //when
            ValueTask<Location> addLocationTask =
                this.locationService.AddLocationAsync(invalidLocation);

            LocationValidationException actualLocationValidationException =
                await Assert.ThrowsAsync<LocationValidationException>(addLocationTask.AsTask);

            //then
            actualLocationValidationException.Should()
                .BeEquivalentTo(expectedLocationValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExcepionAs(expectedLocationValidationException))),
                    Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertLocationAsync(It.IsAny<Location>()),
                    Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
