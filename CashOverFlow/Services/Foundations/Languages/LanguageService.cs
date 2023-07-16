//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System.Threading.Tasks;
using CashOverFlow.Brokers.DateTimes;
using CashOverFlow.Brokers.Loggings;
using CashOverFlow.Brokers.Storages;
using CashOverFlow.Models.Languages;

namespace CashOverFlow.Services.Foundations.Languages
{
    public class LanguageService : ILanguageService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public LanguageService(
            IStorageBroker storageBroker, IDateTimeBroker dateTimeBroker, ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Language> AddLanguageAsync(Language language)
        {
            throw new System.NotImplementedException();
        }
    }
}
