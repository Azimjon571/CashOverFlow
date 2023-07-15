//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using Xeptions;

namespace CashOverFlow.Models.Locations.Exceptions
{
    public class LocationServiceException : Xeption
    {
        public LocationServiceException(Xeption innerException)
            : base(message: "Location service error occurred, contact support", innerException)
        { }
    }
}
