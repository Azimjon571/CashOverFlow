//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System.Threading.Tasks;
using CashOverFlow.Brokers.DateTimes;
using CashOverFlow.Brokers.Loggings;
using CashOverFlow.Brokers.Storages;
using CashOverFlow.Models.Job.Exceptions;
using CashOverFlow.Models.Jobs;

namespace CashOverFlow.Services.Foundations.Job
{
    public partial class JobService : IJobService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public JobService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker, 
            IDateTimeBroker dateTimeBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<Jobs> AddJobAsync(Jobs jobs) =>
        TryCatch(async () =>
        {
            ValidateJobOnAdd(jobs);

            return await this.storageBroker.InsertJobAsync(jobs);
        });
    }
}
