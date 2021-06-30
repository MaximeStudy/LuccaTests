﻿using LuccaDevises.Parser;
using Xunit;

namespace LuccaDevises.Tests.Parser
{
    public class SecondLineParserTest : ParserTest
    {
        [Fact]
        public void GivenASecondLineWithPositiveInteger_ThenLineIsValid()
        {
            //Given
            var positiveInteger = "54";

            //When
            var contentIsValid = secondLineParser.IsValid(positiveInteger);

            //Then
            Assert.True(contentIsValid);
        }

        [Fact]
        public void GivenASecondLineWithoutInteger_ThenLineIsNotValid()
        {
            //Given
            var lineWithoutInteger = "54;PCD";

            //When
            var contentIsValid = secondLineParser.IsValid(lineWithoutInteger);

            //Then
            Assert.False(contentIsValid);
        }
    }
}