//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System.Linq;
using System.Threading.Tasks;
using CashOverFlow.Models.Reviews;
using Microsoft.EntityFrameworkCore;

namespace CashOverFlow.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Review> Reviews { get; set; }

        public async ValueTask<Review> InsertReviewAsync(Review review) =>
            await InsertAsync(review);

        public IQueryable<Review> SelectAllReviews() =>
            SelectAll<Review>();
    }
}
