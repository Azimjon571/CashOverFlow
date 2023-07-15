//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;

namespace CashOverFlow.Models.Job
{
    public class Job
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Level Level { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
    }
}
