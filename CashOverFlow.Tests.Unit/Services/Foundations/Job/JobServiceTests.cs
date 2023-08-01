//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using CashOverFlow.Brokers.DateTimes;
using CashOverFlow.Brokers.Loggings;
using CashOverFlow.Brokers.Storages;
using CashOverFlow.Models.Jobs;
using CashOverFlow.Services.Foundations.Job;
using Moq;
using Tynamix.ObjectFiller;

namespace CashOverFlow.Tests.Unit.Services.Foundations.Job
{
    public partial class JobServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly IJobService jobService;

        public JobServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();
            this.dateTimeBrokerMock = new Mock<IDateTimeBroker>();

            this.jobService=new JobService(
                storageBroker:this.storageBrokerMock.Object,
                loggingBroker:this.loggingBrokerMock.Object,
                dateTimeBroker:this.dateTimeBrokerMock.Object);
        }
        private DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: DateTime.UtcNow).GetValue();
        private Jobs CreateRandomJobs() =>
            CreateJobFiller(date: GetRandomDateTimeOffset()).Create();

        private Filler<Jobs> CreateJobFiller(DateTimeOffset date)
        {
            var filler = new Filler<Jobs>();

            filler.Setup().
                OnType<DateTimeOffset>().Use(date);

            return filler;
        }
    }
}
