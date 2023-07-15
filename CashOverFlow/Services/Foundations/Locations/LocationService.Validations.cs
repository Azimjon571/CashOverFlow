//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using System.Data;
using System.Reflection.Metadata;
using CashOverFlow.Models.Locations;
using CashOverFlow.Models.Locations.Exceptions;

namespace CashOverFlow.Services.Foundations.Locations
{
    public partial class LocationService
    {
        private void ValidateLocationOnAdd(Location location)
        {
            ValidateLocationNotNull(location);

            Validate(
                (Rule: IsInvalid(location.Id), Parameter: nameof(Location.Id)),
                (Rule: IsInvalid(location.Name), Parameter: nameof(Location.Name)),
                (Rule: IsInvalid(location.CreateDate), Parameter: nameof(Location.CreateDate)),
                (Rule: IsInvalid(location.UpdateDate), Parameter: nameof(Location.UpdateDate)),
                (Rule: IsNotRecent(location.CreateDate), Parameter: nameof(Location.CreateDate)),

                (Rule: IsInvalid(
                    firstDate: location.CreateDate,
                    secondDate: location.UpdateDate,
                    secondDateName: nameof(Location.UpdateDate)),
                Parameter: nameof(Location.CreateDate)));
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

        private static dynamic IsInvalid(
            DateTimeOffset firstDate,
            DateTimeOffset secondDate,
            string secondDateName) => new
            {
                Condition = firstDate != secondDate,
                Message = $"Date is not same as {secondDateName}"
            };

        private dynamic IsNotRecent(DateTimeOffset date) => new
        {
            Condition = IsDateNotRecent(date),
            Message = "Date is not recent"
        };

        private bool IsDateNotRecent(DateTimeOffset date)//10:51:20
        {
            DateTimeOffset currentDate = this.dateTimeBroker.GetCurrentDateTimeOffset();//10:51:00
            TimeSpan timeDifference = currentDate.Subtract(date); //-20

            return timeDifference.TotalSeconds is > 60 or < 0;
        }

        private void Validate(params (dynamic Rule, string Parameter)[] validations)
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
