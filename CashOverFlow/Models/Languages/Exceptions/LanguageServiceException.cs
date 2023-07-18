//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using Xeptions;

namespace CashOverFlow.Models.Languages.Exceptions
{
    public class LanguageServiceException : Xeption
    {
        public LanguageServiceException(Xeption innerException)
            :base(message: "Location service error occured, contact support.",innerException)
        {}
    }
}
