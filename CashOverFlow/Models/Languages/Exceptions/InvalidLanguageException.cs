//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using Xeptions;

namespace CashOverFlow.Models.Languages.Exceptions
{
    public class InvalidLanguageException:Xeption
    {
        public InvalidLanguageException()
            :base(message:"Language is invalid.")
        {}
    }
}
