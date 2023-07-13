//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using CashOverFlow.Models.Locations;
using CashOverFlow.Models.Locations.Exceptions;

namespace CashOverFlow.Services.Foundations.Locations
{
    public partial class LocationService
    {
        private static void ValidateLocationOnAdd(Location location)
        {
            ValidateLocationNotNull(location);

            Validate(
                (Rule: IsInvalid(location.Id), Parameter: nameof(location.Id)),
                (Rule: IsInvalid(location.Name), Parameter: nameof(location.Name)),
                (Rule: IsInvalid(location.CreateDate), Parameter: nameof(location.CreateDate)),
                (Rule: IsInvalid(location.UpdateDate), Parameter: nameof(location.UpdateDate)));
        }
        private static void ValidateLocationNotNull(Location location)
        {
            if (location is null)
            {
                throw new NullLocationException();
            }
        }

        private static dynamic IsInvalid(Guid Id) => new
        {
            Condition = Id == Guid.Empty,
            Message = "Id is required"
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Date is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidLocationException = new InvalidLocationException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidLocationException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);

                }
            }

            invalidLocationException.ThrowIfContainsErrors();
        }
    }
}
