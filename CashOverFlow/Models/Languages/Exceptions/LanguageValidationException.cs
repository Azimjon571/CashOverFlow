//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using Xeptions;

namespace CashOverFlow.Models.Languages.Exceptions
{
    public class LanguageValidationException:Xeption
    {
        public LanguageValidationException(Xeption innerException)
            :base(message:"Language validation error occured, fix the errors and try again, innerException")
        {}
    }
}
