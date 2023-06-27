//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

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
        public IQueryable<Job> SelectAlljob() =>
            SelectAll<Job>();
    }
}
