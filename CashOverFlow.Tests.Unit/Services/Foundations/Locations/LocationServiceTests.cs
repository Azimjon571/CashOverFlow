//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using System.Linq.Expressions;
using CashOverFlow.Brokers.Loggings;
using CashOverFlow.Brokers.Storages;
using CashOverFlow.Models.Locations;
using CashOverFlow.Services.Foundations.Locations;
using Moq;
using Tynamix.ObjectFiller;
using Xeptions;

namespace CashOverFlow.Tests.Unit.Services.Foundations.Locations
{
    public partial class LocationServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly ILocationService locationService;

        public LocationServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.locationService = new LocationService(
                storageBroker: this.storageBrokerMock.Object,
                loggingBroker:this.loggingBrokerMock.Object);
        }
        private DateTimeOffset GetRandomDateTimeoffSet() =>
            new DateTimeRange(earliestDate: DateTime.UnixEpoch).GetValue();

        private Expression<Func<Xeption, bool>> SameExcepionAs(Xeption expectedException) =>
            actualException => actualException.SameExceptionAs(expectedException);

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
