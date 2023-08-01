//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System.Threading.Tasks;
using CashOverFlow.Models.Jobs;

namespace CashOverFlow.Services.Foundations.Job
{
    public interface IJobService
    {
        ValueTask<Jobs> AddJobAsync(Jobs jobs);
    }
}
