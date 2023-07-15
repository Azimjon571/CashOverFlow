//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System.Threading.Tasks;
using CashOverFlow.Models.Locations;
using CashOverFlow.Models.Locations.Exceptions;
using FluentAssertions;
using Microsoft.Data.SqlClient;
using Moq;
using Xunit;

namespace CashOverFlow.Tests.Unit.Services.Foundations.Locations
{
    public partial class LocationServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnAddIfDependencyErrorOccursAndLogItAsync()
        {
            //given
            Location someLocation = CreateRandomLocation();
            SqlException sqlException = CreateSqlException();
            var failedLocationStorageException = new FailedLocationStorageException(sqlException);
            var expectedLocationDependencyException = new LocationDependencyException(failedLocationStorageException);

            this.dateTimeBrokerMock.Setup(broker =>
                broker.GetCurrentDateTimeOffset()).Throws(sqlException);

            //when
            ValueTask<Location> addLocationTask =
                this.locationService.AddLocationAsync(someLocation);

            LocationDependencyException actualLocationDependencyException =
                await Assert.ThrowsAsync<LocationDependencyException>(addLocationTask.AsTask);

            //then
            actualLocationDependencyException.Should().
                BeEquivalentTo(expectedLocationDependencyException);

            this.dateTimeBrokerMock.Verify(broker =>
                broker.GetCurrentDateTimeOffset(),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(SameExcepionAs(
                    expectedLocationDependencyException))),
                        Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertLocationAsync(It.IsAny<Location>()),
                    Times.Never);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
