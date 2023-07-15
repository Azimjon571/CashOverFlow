﻿//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using System.Threading.Tasks;
using CashOverFlow.Models.Locations;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Xunit;

namespace CashOverFlow.Tests.Unit.Services.Foundations.Locations
{
    public partial class LocationServiceTests
    {
        [Fact]
        public async Task ShouldAddLocationAsync()
        {
            DateTimeOffset randomDateTime = GetRandomDateTimeoffSet();
            Location randomLocation = CreateRandomLocation(randomDateTime);
            Location inputLocation = randomLocation;
            Location persistedLocation = inputLocation;
            Location expectedLocation = persistedLocation.DeepClone();

            this.dateTimeBrokerMock.Setup(broker => broker.GetCurrentDateTimeOffset())
                .Returns(randomDateTime);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertLocationAsync(inputLocation)).ReturnsAsync(persistedLocation);

            // when
            Location actualLocation = await this.locationService
                .AddLocationAsync(inputLocation);

            // then
            actualLocation.Should().BeEquivalentTo(expectedLocation);

            this.dateTimeBrokerMock.Verify(broker => broker
                .GetCurrentDateTimeOffset(), Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertLocationAsync(inputLocation), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
