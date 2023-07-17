using System;
using System.Data;
using System.Reflection.Metadata;
using CashOverFlow.Models.Languages;
using CashOverFlow.Models.Languages.Exceptions;

namespace CashOverFlow.Services.Foundations.Languages
{
    public partial class LanguageService
    {
        private void ValidationLanguageOnAdd(Language language)
        {
            ValidationLanguageIsNotNull(language);

            Validate(
                (Rule: IsInvalid(language.Id), Parameter: nameof(Language.Id)),
                (Rule: IsInvalid(language.Name), Parameter: nameof(Language.Name)),
                (Rule: IsInvalid(language.CreatedDate), Parameter: nameof(Language.CreatedDate)),
                (Rule: IsInvalid(language.UpdatedDate), Parameter: nameof(Language.UpdatedDate)));
        }

        private static void ValidationLanguageIsNotNull(Language language)
        {
            if (language is null)
            {
                throw new NullLanguageException();
            }
        }

        private static dynamic IsInvalid(Guid Id) => new
        {
            Condition = Id == Guid.Empty,
            Message = "Id is required"
        };
        private static dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };
        private static dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Date is required"
        };

        private void Validate(params(dynamic Rule, string Parameter)[] validations)
        {
            var invalidLanguageException = new InvalidLanguageException();
            foreach ((dynamic rule,string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidLanguageException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidLanguageException.ThrowIfContainsErrors();
        }

    }
}
