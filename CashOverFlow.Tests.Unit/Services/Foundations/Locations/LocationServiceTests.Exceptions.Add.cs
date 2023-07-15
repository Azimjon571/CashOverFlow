//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using System.Threading.Tasks;
using CashOverFlow.Models.Locations;
using CashOverFlow.Models.Locations.Exceptions;
using EFxceptions.Models.Exceptions;
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

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAddIfDupLicateKeyErrorOccursAndLogItAsync()
        {
            //given
            string someMessage = GetRandomString();
            Location someLocation = CreateRandomLocation();
            var duplicateKeyException = new DuplicateKeyException(someMessage);

            var alreadyExistsLocationException = new
                AlreadyExistsLocationException(duplicateKeyException);

            var expectedLocationDependencyValidationException = new
                LocationDependencyValidationException(alreadyExistsLocationException);

            this.dateTimeBrokerMock.Setup(broker =>
            broker.GetCurrentDateTimeOffset()).Throws(duplicateKeyException);

            //when
            ValueTask<Location> addLocationTask =
                this.locationService.AddLocationAsync(someLocation);

            LocationDependencyValidationException actualLocationDependencyValidationException =
                await Assert.ThrowsAsync<LocationDependencyValidationException>(addLocationTask.AsTask);

            //then
            actualLocationDependencyValidationException.Should()
                .BeEquivalentTo(expectedLocationDependencyValidationException);

            this.dateTimeBrokerMock.Verify(broker =>
                broker.GetCurrentDateTimeOffset(), Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExcepionAs(
                    expectedLocationDependencyValidationException))),
                        Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnAddIfServerErrorOccursAndLogItAsync()
        {
            //given
            Location someLocation = CreateRandomLocation();
            var serviceException = new Exception();
            var failedLocationServiceException =
                new FailedLocationServiceException(serviceException);

            var expectedLocationServiceException = new
                LocationServiceException(failedLocationServiceException);

            this.dateTimeBrokerMock.Setup(broker =>
                broker.GetCurrentDateTimeOffset()).Throws(serviceException);

            //when
            ValueTask<Location> addLocationTask =
                this.locationService.AddLocationAsync(someLocation);

            LocationServiceException actualLocationServiceException =
                await Assert.ThrowsAsync<LocationServiceException>(addLocationTask.AsTask);
            //then

            actualLocationServiceException.Should().
                BeEquivalentTo(expectedLocationServiceException);

            this.dateTimeBrokerMock.Verify(broker =>
                broker.GetCurrentDateTimeOffset(), Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExcepionAs(expectedLocationServiceException))),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
