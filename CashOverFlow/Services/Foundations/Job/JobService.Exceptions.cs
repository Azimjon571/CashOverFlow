using System.Threading.Tasks;
using CashOverFlow.Models.Job.Exceptions;
using CashOverFlow.Models.Jobs;
using Xeptions;

namespace CashOverFlow.Services.Foundations.Job
{
    public partial class JobService
    {
        private delegate ValueTask<Jobs> ReturningJobFunction();

        private async ValueTask<Jobs> TryCatch(ReturningJobFunction returningJobFunction)
        {
            try
            {
                return await returningJobFunction();
            }
            catch (NullJobException nullJobExceprion)
            {
                throw CreateAndLogJobValidationException(nullJobExceprion);
            }
            catch(InvalidJobException  invalidJobExceprion)
            {
                throw CreateAndLogJobValidationException(invalidJobExceprion);
            }
        }

        private JobValidationException CreateAndLogJobValidationException(Xeption exception)
        {
            var jobValidationException =
                    new JobValidationException(exception);

            this.loggingBroker.LogError(jobValidationException);

            return jobValidationException;
        }
    }
}
