//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using Xeptions;

namespace CashOverFlow.Models.Locations.Exceptions
{
    public class AlreadyExistsLocationException : Xeption
    {
        public AlreadyExistsLocationException(Exception innerException)
            : base(message: "Location already exists", innerException)
        { }
    }
}
