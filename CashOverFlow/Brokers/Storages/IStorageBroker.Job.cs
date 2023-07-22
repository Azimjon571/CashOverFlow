//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using CashOverFlow.Models.Jobs;

namespace CashOverFlow.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Jobs> InsertJobAsync(Jobs job);
        IQueryable<Jobs> SelectAlljobAsync();
        ValueTask<Jobs> SelectJobByIdAsync(Guid Id);
        ValueTask<Jobs> UpdateJobAsync(Jobs job);
        ValueTask<Jobs> DeletejobAsync(Jobs job);
    }
}
