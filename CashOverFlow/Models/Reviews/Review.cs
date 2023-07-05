//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;

namespace CashOverFlow.Models.Reviews
{
    public class Review
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public int Stars { get; set; }
        public string Thoughts { get; set; }
    }
}
