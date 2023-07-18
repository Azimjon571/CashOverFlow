//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using Xeptions;

namespace CashOverFlow.Models.Languages.Exceptions
{
    public class FailedLanguageStorageException : Xeption
    {
        public FailedLanguageStorageException(Exception innerException)
        : base(message: "Failed language storage exception occurred, contact support.", innerException)
        { }
    }
}
