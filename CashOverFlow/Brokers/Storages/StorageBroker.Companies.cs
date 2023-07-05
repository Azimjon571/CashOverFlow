//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using CashOverFlow.Models.Companies;
using Microsoft.EntityFrameworkCore;

namespace CashOverFlow.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Company> Companies { get; set; }
    }
}
