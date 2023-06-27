//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using CashOverFlow.Models.Languages;
using Microsoft.EntityFrameworkCore;

namespace CashOverFlow.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Language> Languages { get; set; }

        public async ValueTask<Language> InsertLanguageAsync(Language language) =>
            await InsertAsync(language);
        public IQueryable<Language> SelectAllLanguages() =>
            SelectAll<Language>();
        public async ValueTask<Language> SelectLanguageByIdAsync(Guid Id)=>
            await SelectAsync<Language>(Id);
    }
}
