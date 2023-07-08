//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using CashOverFlow.Models.Companies;

namespace CashOverFlow.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Company> InsertCompanyAsync(Company company);
        IQueryable<Company> SelectAllCompanies();
        ValueTask<Company> SelectCompanyByIdAsync(Guid companyId);
        ValueTask<Company> UpdateCompanyAsync(Company company);
        ValueTask<Company> DeleteCompanyAsync(Company company);
    }
}
