//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using Xeptions;

namespace CashOverFlow.Models.Locations.Exceptions
{
    public class NullLocationException: Xeption
    {
        public NullLocationException()
            :base(message:"Location is null.")
        {}
    }
}
