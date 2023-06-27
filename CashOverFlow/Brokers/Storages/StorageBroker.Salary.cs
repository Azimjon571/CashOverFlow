//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using CashOverFlow.Models.Salary;
using Microsoft.EntityFrameworkCore;

namespace CashOverFlow.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Salary> Salaries { get; set; }

        public async ValueTask<Salary> InsertSalaryAsync(Salary salary) =>
            await InsertAsync(salary);

        public IQueryable<Salary> SelectSalaryAsync() =>
            SelectAll<Salary>();

        public async ValueTask<Salary> SelectSalaryByIdAsync(Guid salaryId) =>
            await SelectAsync<Salary>(salaryId);
    }
}
