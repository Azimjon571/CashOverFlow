//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using CashOverFlow.Brokers.Storages;
using CashOverFlow.Models.Locations;
using CashOverFlow.Services.Foundations.Locations;
using Moq;
using Tynamix.ObjectFiller;

namespace CashOverFlow.Tests.Unit.Services.Foundations.Locations
{
    public partial class LocationServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly ILocationService locationService;

        public LocationServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();

            this.locationService = new LocationService(
                storageBroker: this.storageBrokerMock.Object);
        }
        private DateTimeOffset GetRandomDateTimeoffSet() =>
            new DateTimeRange(earliestDate: DateTime.UnixEpoch).GetValue();

        private Location CreateRandomLocation() =>
            CreateLocationFiller(dates:GetRandomDateTimeoffSet()).Create();

        private Filler<Location> CreateLocationFiller(DateTimeOffset dates)
        {
            var filler = new Filler<Location>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(dates);

            return filler;
        }
    }
}
