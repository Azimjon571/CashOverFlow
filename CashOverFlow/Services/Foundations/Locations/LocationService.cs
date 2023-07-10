//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using System.Threading.Tasks;
using CashOverFlow.Brokers.Loggings;
using CashOverFlow.Brokers.Storages;
using CashOverFlow.Models.Locations;

namespace CashOverFlow.Services.Foundations.Locations
{
    public partial class LocationService: ILocationService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public LocationService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Location> AddLocationAsync(Location location) =>
        TryCatch(async () =>
        {
            ValidateLocationNotNull(location);

            return await this.storageBroker.InsertLocationAsync(location);
        });
    }
}
