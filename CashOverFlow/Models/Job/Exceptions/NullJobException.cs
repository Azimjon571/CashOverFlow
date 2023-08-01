//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using Xeptions;

namespace CashOverFlow.Models.Job.Exceptions
{
    public class NullJobException : Xeption
    {
        public NullJobException()
            : base(message: "Job is null.")
        {}
    }
}
