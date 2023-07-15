//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;

namespace CashOverFlow.Models.Locations
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Country Country { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
    }
}
