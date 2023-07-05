//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System.Linq;
using System.Threading.Tasks;
using CashOverFlow.Models.Reviews;

namespace CashOverFlow.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Review> InsertReviewAsync(Review review);
        IQueryable<Review> SelectAllReviews();
    }
}
