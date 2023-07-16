//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using Xeptions;

namespace CashOverFlow.Models.Languages.Exceptions
{
    public class NullLanguageException:Xeption
    {
        public NullLanguageException()
            :base(message:"Language is null.")
        {}
    }
}
