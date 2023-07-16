//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System.Threading.Tasks;
using CashOverFlow.Models.Languages;

namespace CashOverFlow.Services.Foundations.Languages
{
    public interface ILanguageService
    {
        ValueTask<Language>AddLanguageAsync(Language language);
    }
}
