//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using Xeptions;

namespace CashOverFlow.Models.Locations.Exceptions
{
    public class InvalidLocationException : Xeption
    {
        public InvalidLocationException()
            : base(message: "Location is incvalid.")
        { }
    }
}
