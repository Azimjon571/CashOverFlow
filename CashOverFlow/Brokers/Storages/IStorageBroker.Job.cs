//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System.Linq;
using System.Threading.Tasks;
using CashOverFlow.Models.Job;

namespace CashOverFlow.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Job> InsertJobAsync(Job job);
        IQueryable<Job> SelectAlljob();
    }
}
