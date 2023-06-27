//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using EFxceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CashOverFlow.Brokers.Storages
{
    public partial class StorageBroker: EFxceptionsContext
    {
        private readonly IConfiguration configuration;

        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectingString = this.configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectingString);
        }
        public override void Dispose()
        {}
    }
}
