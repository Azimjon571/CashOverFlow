//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System.Threading.Tasks;
using CashOverFlow.Models.Locations;
using CashOverFlow.Models.Locations.Exceptions;
using EFxceptions.Models.Exceptions;
using Microsoft.Data.SqlClient;
using Xeptions;

namespace CashOverFlow.Services.Foundations.Locations
{
    public partial class LocationService
    {
        private delegate ValueTask<Location> ReturningLocationFuntion();

        private async ValueTask<Location> TryCatch(ReturningLocationFuntion returningLocationFuntion)
        {
            try
            {
                return await returningLocationFuntion();
            }
            catch (NullLocationException nullLocationException)
            {
                throw CreateAndLogValidationException(nullLocationException);
            }
            catch (InvalidLocationException invalidLocationException)
            {
                throw CreateAndLogValidationException(invalidLocationException);
            }
            catch (SqlException sqlException)
            {
                var failedLocationStorageException = new
                    FailedLocationStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedLocationStorageException);
            }
            catch(DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistsLocationException = new 
                    AlreadyExistsLocationException(duplicateKeyException);

                throw CreateAndLogDependencyValidationException(alreadyExistsLocationException);
            }
        }

        private LocationValidationException CreateAndLogValidationException(Xeption exception)
        {
            var locationValidationException = new
                                LocationValidationException(exception);

            this.loggingBroker.LogError(locationValidationException);

            return locationValidationException;
        }

        private LocationDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var locationDependencyException = new
                LocationDependencyException(exception);

            this.loggingBroker.LogCritical(locationDependencyException);

            return locationDependencyException;
        }

        private LocationDependencyValidationException CreateAndLogDependencyValidationException(Xeption exception)
        {
            var locationDependencyValidationException = new
                LocationDependencyValidationException(exception);

            this.loggingBroker.LogError(locationDependencyValidationException);

            return locationDependencyValidationException;
        }
    }
}
