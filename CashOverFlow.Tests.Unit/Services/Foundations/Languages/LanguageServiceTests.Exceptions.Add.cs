//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System.Threading.Tasks;
using CashOverFlow.Models.Languages;
using CashOverFlow.Models.Languages.Exceptions;
using FluentAssertions;
using Microsoft.Data.SqlClient;
using Moq;
using Xunit;

namespace CashOverFlow.Tests.Unit.Services.Foundations.Languages
{
    public partial class LanguageServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnAddIfLanguageDependencyErrorOccuredAndLogIfAsync()
        {
            //given
            Language someLanguage = CreateRandomLanguage();
            SqlException sqlException = CreateSqlException();
            var failedLanguageStorageException = new FailedLanguageStorageException(sqlException);
            var expectedLanguageDependencyException = new LanguageDependencyException(failedLanguageStorageException);

            this.dateTimeBrokerMock.Setup(broker =>
                broker.GetCurrentDateTimeOffset()).Throws(sqlException);
            //when
            ValueTask<Language> addLanguageTask = 
                this.languageService.AddLanguageAsync(someLanguage);

            LanguageDependencyException actualLanguageDependencyException =
                await Assert.ThrowsAsync<LanguageDependencyException>(addLanguageTask.AsTask);

            //then
            actualLanguageDependencyException.Should()
                .BeEquivalentTo(expectedLanguageDependencyException);

            this.dateTimeBrokerMock.Verify(broker =>
                broker.GetCurrentDateTimeOffset(), Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(SameExceptionAs(expectedLanguageDependencyException))), 
                    Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertLanguageAsync(It.IsAny<Language>()), Times.Never);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
