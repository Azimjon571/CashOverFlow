using Xeptions;

namespace CashOverFlow.Models.Job.Exceptions
{
    public class InvalidJobException : Xeption
    {
        public InvalidJobException()
            :base(message:"Job is invalid.")
        {}
    }
}
