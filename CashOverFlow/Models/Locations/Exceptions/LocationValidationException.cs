//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using Xeptions;

namespace CashOverFlow.Models.Locations.Exceptions
{
    public class LocationValidationException:Xeption
    {
        public LocationValidationException(Xeption innerException)
            : base(message: "Location validation error occured, fix the errors and try again", innerException)
        {}
    }
}
