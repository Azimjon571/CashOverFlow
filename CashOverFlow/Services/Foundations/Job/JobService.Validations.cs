//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using CashOverFlow.Models.Jobs;
using CashOverFlow.Models.Job.Exceptions;
using System;
using System.Data;
using System.Reflection.Metadata;
using CashOverFlow.Models.Locations.Exceptions;

namespace CashOverFlow.Services.Foundations.Job
{
    public partial class JobService
    {
        private void ValidateJobOnAdd(Jobs jobs)
        {
            ValidationJobIsNotNull(jobs);

            Validate(
                (Rule: IsInvalid(jobs.Id), Parameter: nameof(Jobs.Id)),
                (Rule: IsInvalid(jobs.Title), Parameter: nameof(Jobs.Title)),
                (Rule: IsInvalid(jobs.CreatedDate), Parameter: nameof(Jobs.CreatedDate)),
                (Rule: IsInvalid(jobs.UpdatedDate), Parameter: nameof(Jobs.UpdatedDate)));
        }

        private static void ValidationJobIsNotNull(Jobs jobs)
        {
            if (jobs is null)
            {
                throw new NullJobException();
            }
        }

        private static dynamic IsInvalid(Guid Id) => new
        {
            Condition=Id==Guid.Empty,
            Message="Id is required"
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Title is required"
        };

        private static dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Date is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidJobException = new InvalidJobException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidJobException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidJobException.ThrowIfContainsErrors();
        }
    }
}
