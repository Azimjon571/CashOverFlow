//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using CashOverFlow.Models.Locations.Exceptions;
using CashOverFlow.Models.Locations;

namespace CashOverFlow.Services.Foundations.Locations
{
    public partial class LocationService
    {
        private static void ValidateLocationNotNull(Location location)
        {
            if (location is null)
            {
                throw new NullLocationException();
            }
        }
    }
}
