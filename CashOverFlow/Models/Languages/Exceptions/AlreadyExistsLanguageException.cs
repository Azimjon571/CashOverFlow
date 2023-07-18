//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using Xeptions;

namespace CashOverFlow.Models.Languages.Exceptions
{
    public class AlreadyExistsLanguageException:Xeption
    {
        public AlreadyExistsLanguageException(Exception innerException)
            :base(message: "Location already exists.",innerException)
        {}
    }
}
