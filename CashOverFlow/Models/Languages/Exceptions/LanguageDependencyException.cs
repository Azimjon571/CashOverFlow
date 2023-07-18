//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using Xeptions;

namespace CashOverFlow.Models.Languages.Exceptions
{
    public class LanguageDependencyException:Xeption
    {
        public LanguageDependencyException(Xeption innerException)
            : base(message: "Language dependency exception occurred, contact support",innerException)
        {}
    }
}
