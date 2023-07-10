//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System.Threading.Tasks;
using CashOverFlow.Models.Locations;
using CashOverFlow.Models.Locations.Exceptions;
using Xeptions;

namespace CashOverFlow.Services.Foundations.Locations
{
    public partial class LocationService
    {
        private delegate ValueTask<Location> ReturningLocationFuntion();

        private async ValueTask<Location>TryCatch(ReturningLocationFuntion returningLocationFuntion)
        {
            try
            {
                return await returningLocationFuntion();
            }
            catch (NullLocationException nullLocationException)
            {
                throw CreateAndLogValidationException(nullLocationException);
            }
        }

        private LocationValidationException CreateAndLogValidationException(Xeption exception)
        {
            var locationValidationException = new
                                LocationValidationException(exception);

            this.loggingBroker.LogError(locationValidationException);

            return locationValidationException;
        }
    }
}
