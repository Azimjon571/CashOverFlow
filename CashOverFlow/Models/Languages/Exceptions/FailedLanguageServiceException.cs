//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using Xeptions;

namespace CashOverFlow.Models.Languages.Exceptions
{
    public class FailedLanguageServiceException : Xeption
    {
        public FailedLanguageServiceException(Exception innerException)
            : base(message: "Language service error occured, contact support.", innerException)
        { }
    }
}
