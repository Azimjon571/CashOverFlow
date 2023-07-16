//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using CashOverFlow.Brokers.DateTimes;
using CashOverFlow.Brokers.Loggings;
using CashOverFlow.Brokers.Storages;
using CashOverFlow.Models.Languages;
using CashOverFlow.Services.Foundations.Languages;
using Moq;
using Tynamix.ObjectFiller;

namespace CashOverFlow.Tests.Unit.Services.Foundations.Languages
{
    public partial class LanguageServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ILanguageService languageService;

        public LanguageServiceTests()
        {
            this.storageBrokerMock=new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();
            this.dateTimeBrokerMock=new Mock<IDateTimeBroker>();

            this.languageService = new LanguageService(
                storageBroker: this.storageBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object,
                dateTimeBroker: this.dateTimeBrokerMock.Object);

        }

        private DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: DateTime.UtcNow).GetValue();

        private Language CreateRandomLanguage() =>
            CreateLanguageFiller(dates:GetRandomDateTimeOffset()).Create();

        private Language CreateRandomLanguage(DateTimeOffset dates) =>
            CreateLanguageFiller(dates).Create();

        private Filler<Language> CreateLanguageFiller(DateTimeOffset dates)
        {
            var filler = new Filler<Language>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(dates);

            return filler;
        }
    }
}
