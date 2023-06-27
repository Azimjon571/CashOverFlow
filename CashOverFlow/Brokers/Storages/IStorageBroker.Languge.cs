//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System.Threading.Tasks;
using CashOverFlow.Models.Languages;

namespace CashOverFlow.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Language> InsertLanguageAsync(Language language);
        ValueTask<Language> SelectLanguageByIdAsync(Language language);
    }
}
