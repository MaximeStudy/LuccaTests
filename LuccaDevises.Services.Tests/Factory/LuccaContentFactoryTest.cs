using LuccaDevises.Services.Factory;
using Xunit;
using Moq;
using LuccaDevises.Services.Parser;
using LuccaDevises.Domain.Input;
using System;
using System.Reflection;

namespace LuccaDevises.Services.Tests.Factory
{
    public class LuccaContentFactoryTest
    {
        private readonly LuccaContentFactory luccaContentFactory;
        private readonly Mock<ContentParserForTest> mockContentParser;

        public LuccaContentFactoryTest()
        {
            mockContentParser = new Mock<ContentParserForTest>();

            luccaContentFactory = new LuccaContentFactory(mockContentParser.Object);
        }

        [Fact]
        public void GivenAnInExistingFile_WhenCreateValidInputState_ThenThrowException()
        {
            //Given
            InputState expectedInputFile = new InputState();
            //mockContentParser.Setup(cp => cp.Parse(new List<string>())).Returns(expectedInputFile);
            var anInexistingPath = "a path";

            //When

            //Then
            Assert.Throws<ArgumentException>(() => luccaContentFactory.Create(anInexistingPath));
        }

        [Fact]
        public void GivenAnExistingFile_WhenCreateValidInputState_ThenParseFile()
        {
            //Given
            InputState expectedInputFile = new InputState();
            //mockContentParser.Setup(cp => cp.Parse(new List<string>())).Returns(expectedInputFile);
            var anExistingPath = Assembly.GetEntryAssembly().GetName().CodeBase;

            //When
            var res = luccaContentFactory.Create(anExistingPath);
            //Then

            Assert.NotNull(res);
        }

        public class ContentParserForTest : ContentParser
        {
            public ContentParserForTest() : base()
            {
            }

            public ContentParserForTest(FirstLineParser firstLineParser, SecondLineParser secondLineParser, NthLineParser nthLineParser) : base(firstLineParser, secondLineParser, nthLineParser)
            {
            }
        }
    }
}