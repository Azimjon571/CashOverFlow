//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using CashOverFlow.Models.Jobs;
using Microsoft.EntityFrameworkCore;

namespace CashOverFlow.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Jobs> Jobs { get; set; }

        public async ValueTask<Jobs> InsertJobAsync(Jobs job) =>
            await InsertAsync(job);

        public IQueryable<Jobs> SelectAlljobAsync() =>
            SelectAll<Jobs>();

        public async ValueTask<Jobs> SelectJobByIdAsync(Guid Id) =>
            await SelectAsync<Jobs>(Id);

        public async ValueTask<Jobs> UpdateJobAsync(Jobs job) =>
            await UpdateAsync(job);

        public async ValueTask<Jobs> DeletejobAsync(Jobs job) =>
            await DeleteAsync(job);
    }
}
