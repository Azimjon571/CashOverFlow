//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using CashOverFlow.Models.Job;
using Microsoft.EntityFrameworkCore;

namespace CashOverFlow.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Job> Jobs { get; set; }

        public async ValueTask<Job> InsertJobAsync(Job job)=>
            await InsertAsync(job);
        public IQueryable<Job> SelectAlljobAsync() =>
            SelectAll<Job>();

        public async ValueTask<Job> SelectJobById(Guid Id) =>
            await SelectAsync<Job>(Id);
    }
}
