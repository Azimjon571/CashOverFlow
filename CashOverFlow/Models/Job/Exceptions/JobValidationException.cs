//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using Xeptions;

namespace CashOverFlow.Models.Job.Exceptions
{
    public class JobValidationException : Xeption
    {
        public JobValidationException(Xeption innerException)
            :base(message:"Job validation error occured, fix the errors and try again",innerException)
        {}
    }
}
