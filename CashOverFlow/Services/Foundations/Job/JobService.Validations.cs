//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using CashOverFlow.Models.Jobs;
using CashOverFlow.Models.Job.Exceptions;

namespace CashOverFlow.Services.Foundations.Job
{
    public partial class JobService
    {
        private void ValidateJobOnAdd(Jobs jobs)
        {
            ValidationJobIsNotNull(jobs);
        }

        private static void ValidationJobIsNotNull(Jobs jobs)
        {
            if (jobs is null)
            {
                throw new NullJobException();
            }
        }
    }
}
