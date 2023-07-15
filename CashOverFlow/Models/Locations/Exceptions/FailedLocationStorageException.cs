//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using Xeptions;

namespace CashOverFlow.Models.Locations.Exceptions
{
    public class FailedLocationStorageException : Xeption
    {
        public FailedLocationStorageException(Exception innerException)
            : base(message: "Failed location storage exception occurred, contact support.", innerException)
        { }
    }
}
