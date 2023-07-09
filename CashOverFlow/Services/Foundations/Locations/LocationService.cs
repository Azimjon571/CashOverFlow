//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using System.Threading.Tasks;
using CashOverFlow.Brokers.Storages;
using CashOverFlow.Models.Locations;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CashOverFlow.Services.Foundations.Locations
{
    public class LocationService: ILocationService
    {
        private IStorageBroker storageBroker;

        public  LocationService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker; 

        public async ValueTask<Location>AddLocationAsync(Location location)=>
            await this.storageBroker.InsertLocationAsync(location);
    }
}
