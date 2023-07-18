﻿//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using Xeptions;

namespace CashOverFlow.Models.Languages.Exceptions
{
    public class LanguageDependencyValidationException : Xeption
    {
        public LanguageDependencyValidationException(Xeption innerException)
            : base(message: "Location dependency validation error occurred, fix the error and try again.", innerException)
        { }
    }
}
