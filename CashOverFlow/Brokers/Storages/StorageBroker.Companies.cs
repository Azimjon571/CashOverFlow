//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using CashOverFlow.Models.Companies;
using Microsoft.EntityFrameworkCore;

namespace CashOverFlow.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Company> Companies { get; set; }

        public async ValueTask<Company> InsertCompanyAsync(Company company) =>
            await InsertAsync(company);

        public IQueryable<Company> SelectAllCompanies() =>
            SelectAll<Company>();

        public async ValueTask<Company> SelectCompanyByIdAsync(Guid companyId) =>
            await SelectAsync<Company>(companyId);

        public async ValueTask<Company> UpdateCompanyAsync(Company company) =>
            await UpdateAsync(company);
    }
}
