//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using CashOverFlow.Models.Locations;

namespace CashOverFlow.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Location> InsertLocationAsync(Location location);
        IQueryable<Location> SelectLocationAsync();
        ValueTask<Location> SelectByIdLocationAsync(Guid Id);
        ValueTask<Location> UpdateLocationAsync(Location location);
    }
}
