//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using Xeptions;

namespace CashOverFlow.Models.Locations.Exceptions
{
    public class FailedLocationServiceException:Xeption
    {
        public FailedLocationServiceException(Exception innerException)
            :base(message:"Location service error occured, contact support.",innerException)
        {}
    }
}
