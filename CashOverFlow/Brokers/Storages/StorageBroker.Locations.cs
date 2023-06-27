//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using CashOverFlow.Models.Locations;
using Microsoft.EntityFrameworkCore;

namespace CashOverFlow.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Location> Locations { get; set; }

        public async ValueTask<Location> InsertLocationAsync(Location location) =>
            await InsertAsync(location);

        public IQueryable<Location> SelectLocationAsync() =>
            SelectAll<Location>();

        public async ValueTask<Location> SelectByIdLocationAsync(Guid Id) =>
            await SelectAsync<Location>(Id);

        public async ValueTask<Location> UpdateLocationAsync(Location location) =>
            await UpdateAsync(location);

        public async ValueTask<Location> DeleteLocationAsync(Location location) =>
            await DeleteAsync(location);
    }
}
