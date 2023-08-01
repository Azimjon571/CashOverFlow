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
    public class JobService : IJobService
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

        public async ValueTask<Jobs> AddJobAsync(Jobs jobs)
        {
            try
            {
                if (jobs is null)
                {
                    throw new NullJobException();
                }
                
                return await this.storageBroker.InsertJobAsync(jobs);
            }
            catch (NullJobException nullJobExceprion)
            {
                var jobValidationException =
                    new JobValidationException(nullJobExceprion);

                this.loggingBroker.LogError(jobValidationException);

                throw jobValidationException;
            }
        }
    }
}
