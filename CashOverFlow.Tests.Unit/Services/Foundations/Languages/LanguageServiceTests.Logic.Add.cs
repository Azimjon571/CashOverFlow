//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using System.Threading.Tasks;
using CashOverFlow.Models.Languages;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Xunit;

namespace CashOverFlow.Tests.Unit.Services.Foundations.Languages
{
    public partial class LanguageServiceTests
    {
        [Fact]
        public async Task ShouldAddLanguageAsync()
        {
            //given
            Language randomLanguage = CreateRandomLanguage();
            Language inputLanguage = randomLanguage;
            Language persistedLanguage = inputLanguage;
            Language expectedLanguage = persistedLanguage.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.InsertLanguageAsync(inputLanguage)).ReturnsAsync(persistedLanguage);

            //when
            Language actualLanguage = await this.languageService
                .AddLanguageAsync(inputLanguage);

            //then
            actualLanguage.Should().BeEquivalentTo(expectedLanguage);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertLanguageAsync(inputLanguage), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
