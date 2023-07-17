//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System.Threading.Tasks;
using CashOverFlow.Models.Languages;
using CashOverFlow.Models.Languages.Exceptions;
using FluentAssertions;
using Moq;
using Xunit;

namespace CashOverFlow.Tests.Unit.Services.Foundations.Languages
{
    public partial class LanguageServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfLanguageInpulIsNullAndLogItAsync()
        {
            //given
            Language nullLanguage = null;
            var nullLanguageException = new NullLanguageException();
            
            var expectedLanguageValidationException =
                new LanguageValidationException(nullLanguageException);

            //when
            ValueTask<Language> addLanguageTask =
                this.languageService.AddLanguageAsync(nullLanguage);

            LanguageValidationException actualLanguageValidationException =
                await Assert.ThrowsAsync<LanguageValidationException>(addLanguageTask.AsTask);

            //then
            actualLanguageValidationException.Should().BeEquivalentTo(expectedLanguageValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedLanguageValidationException))), Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertLanguageAsync(It.IsAny<Language>()), Times.Never);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnAddIfLanguageIsInvalidAndLogItAsync(
            string invalidText)
        {
            //given
            var invalidLanguage = new Language
            {
                Name = invalidText
            };

            var invalidLanguageException = new InvalidLanguageException();

            invalidLanguageException.AddData(
                key: nameof(Language.Id),
                values: "Id is required");

            invalidLanguageException.AddData(
                key: nameof(Language.CreatedDate),
                values: "Date is required");
            
            invalidLanguageException.AddData(
                key: nameof(Language.UpdatedDate),
                values: "Date is required");

            var expectedLanguageValidationException = 
                new LanguageValidationException(invalidLanguageException);

            //when
            ValueTask<Language> addLanguageTask =
                this.languageService.AddLanguageAsync(invalidLanguage);

            LanguageValidationException actualLanguageValidationException =
                await Assert.ThrowsAsync<LanguageValidationException>(addLanguageTask.AsTask);

            //then
            actualLanguageValidationException.Should().BeEquivalentTo(expectedLanguageValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedLanguageValidationException))), 
                        Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertLanguageAsync(It.IsAny<Language>()),
                    Times.Never);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
