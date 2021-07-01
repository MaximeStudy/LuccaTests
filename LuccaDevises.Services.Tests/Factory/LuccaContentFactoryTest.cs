using LuccaDevises.Services.Factory;
using Xunit;
using Moq;
using LuccaDevises.Services.Parser;
using LuccaDevises.Domain.Input;
using System;
using LuccaDevises.Services.Wrapper;
using System.Collections.Generic;

namespace LuccaDevises.Services.Tests.Factory
{
    public class LuccaContentFactoryTest
    {
        private readonly LuccaContentFactory luccaContentFactory;
        private readonly Mock<IContentParser> mockContentParser;
        private readonly Mock<IFileWrapper> mockFileWrapper;

        public LuccaContentFactoryTest()
        {
            mockContentParser = new Mock<IContentParser>();
            mockFileWrapper = new Mock<IFileWrapper>();

            luccaContentFactory = new LuccaContentFactory(mockContentParser.Object, mockFileWrapper.Object);
        }

        [Fact]
        public void GivenAnInExistingFile_WhenCreateValidInputState_ThenParseIsCalled()
        {
            //Given
            InputState expectedInputFile = new InputState();
            var anInexistingPath = "a path";
            var emptyFile = "";
            var emptyList = new List<string>();
            mockFileWrapper.Setup(fw => fw.Exists(It.IsAny<string>())).Returns(true);
            mockFileWrapper.Setup(fw => fw.ReadAllText(It.IsAny<string>())).Returns(emptyFile);
            mockContentParser.Setup(cp => cp.Parse(It.IsAny<List<string>>())).Returns(expectedInputFile);

            //When
            luccaContentFactory.Create(anInexistingPath);

            //Then
            mockContentParser.Verify(v => v.Parse(It.IsAny<List<string>>()));
        }

        //[Fact]
        //public void GivenAnExistingFile_WhenCreateValidInputState_ThenParseFile()
        //{
        //    //Given
        //    InputState expectedInputFile = new InputState();
        //    var mockContentParser = new Mock<ContentParserForTest>();
        //    //mockContentParser.Setup(cp => cp.Parse(It.IsAny<List<string>>())).Returns(expectedInputFile);

        //    var contentFactory = new LuccaContentFactory(mockContentParser.Object, mockFileWrapper.Object);

        //    //When
        //    var res = luccaContentFactory.Create("");
        //    //Then

        //    Assert.NotNull(res);
        //}
    }
}