//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

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
            //given
            Location randomLocation = CreateRandomLocation();
            Location inputLocation = randomLocation;
            Location storageLocation = inputLocation;
            Location expectedLocation = storageLocation.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.InsertLocationAsync(inputLocation)).
                    ReturnsAsync(expectedLocation);

            //when
            Location actualLocation = await this.locationService
                .AddLocationAsync(inputLocation);

            //then

            actualLocation.Should().BeEquivalentTo(expectedLocation);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertLocationAsync(inputLocation),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
