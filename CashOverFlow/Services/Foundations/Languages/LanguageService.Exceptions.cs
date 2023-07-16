//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System.Threading.Tasks;
using CashOverFlow.Models.Languages;
using CashOverFlow.Models.Languages.Exceptions;
using Xeptions;

namespace CashOverFlow.Services.Foundations.Languages
{
    public partial class LanguageService
    {
        private delegate ValueTask<Language> ReturningLanguageFunction();

        private async ValueTask<Language>TryCatch(ReturningLanguageFunction returningLanguageFunction)
        {
            try
            {
                return await returningLanguageFunction();
            }
            catch (NullLanguageException nullLanguageException)
            {
                throw CreateAndLogLanguageValidationException(nullLanguageException);
            }
        }

        private LanguageValidationException CreateAndLogLanguageValidationException(Xeption exception)
        {
            var languageValidationException = new LanguageValidationException(exception);
            
            this.loggingBroker.LogError(languageValidationException);
            
            return languageValidationException;
        }
    }
}
