using CashOverFlow.Models.Languages;
using CashOverFlow.Models.Languages.Exceptions;

namespace CashOverFlow.Services.Foundations.Languages
{
    public partial class LanguageService
    {
        private void ValidationLanguageOnAdd(Language language)
        {
            ValidationLanguageIsNotNull(language);
        }

        private static void ValidationLanguageIsNotNull(Language language)
        {
            if (language is null)
            {
                throw new NullLanguageException();
            }
        }
    }
}
