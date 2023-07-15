//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using Xeptions;

namespace CashOverFlow.Models.Locations.Exceptions
{
    public class LocationDependencyException : Xeption
    {
        public LocationDependencyException(Xeption innerException)
            : base(message: "Loaction dependency exception occurred, contact support", innerException)
        { }
    }
}
