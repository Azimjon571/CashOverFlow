//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;

namespace CashOverFlow.Models.Salary
{
    public class Salary
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public int Experience { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid LocationId { get; set; }
        public Guid JobId { get; set; }
    }
}
