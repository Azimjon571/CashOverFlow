//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using System.Threading.Tasks;
using CashOverFlow.Models.Languages;
using CashOverFlow.Models.Languages.Exceptions;
using EFxceptions.Models.Exceptions;
using Microsoft.Data.SqlClient;
using Xeptions;

namespace CashOverFlow.Services.Foundations.Languages
{
    public partial class LanguageService
    {
        private delegate ValueTask<Language> ReturningLanguageFunction();

        private async ValueTask<Language> TryCatch(ReturningLanguageFunction returningLanguageFunction)
        {
            try
            {
                return await returningLanguageFunction();
            }
            catch (NullLanguageException nullLanguageException)
            {
                throw CreateAndLogLanguageValidationException(nullLanguageException);
            }
            catch (InvalidLanguageException invalidLanguageException)
            {
                throw CreateAndLogLanguageValidationException(invalidLanguageException);
            }
            catch (SqlException sqlException)
            {
                var failedLanguageStorageException =
                    new FailedLanguageStorageException(sqlException);

                throw CreateAndLogLanguageCriticalDependencyException(failedLanguageStorageException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistsLanguageException =
                    new AlreadyExistsLanguageException(duplicateKeyException);

                throw CreateAndLogDependencyValidationException(alreadyExistsLanguageException);
            }
            catch (Exception exception)
            {
                var failedLanguageServiceException =
                    new FailedLanguageServiceException(exception);

                throw CreateAndLogServiceException(failedLanguageServiceException);
            }
        }

        private LanguageValidationException CreateAndLogLanguageValidationException(Xeption exception)
        {
            var languageValidationException = new LanguageValidationException(exception);

            this.loggingBroker.LogError(languageValidationException);

            return languageValidationException;
        }

        private LanguageDependencyException CreateAndLogLanguageCriticalDependencyException(Xeption exception)
        {
            var languageDependencyException = new LanguageDependencyException(exception);
            this.loggingBroker.LogCritical(languageDependencyException);

            return languageDependencyException;
        }

        private LanguageDependencyValidationException CreateAndLogDependencyValidationException(Xeption exception)
        {
            var languageDependencyValidationException =
                new LanguageDependencyValidationException(exception);

            this.loggingBroker.LogError(languageDependencyValidationException);

            return languageDependencyValidationException;
        }

        private LanguageServiceException CreateAndLogServiceException(Xeption exception)
        {
            var languageServiceException =
                new LanguageServiceException(exception);

            this.loggingBroker.LogError(languageServiceException);

            return languageServiceException;
        }
    }
}
