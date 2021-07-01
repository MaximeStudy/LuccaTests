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
        public void GivenAFile_WhenCreateInputState_ThenVerifyIfFileExists()
        {
            InputState expectedInputFile = new InputState();
            var aFilePath = "a path";
            var emptyFile = "";
            mockFileWrapper.Setup(fw => fw.Exists(It.IsAny<string>())).Returns(true);
            mockFileWrapper.Setup(fw => fw.ReadAllText(It.IsAny<string>())).Returns(emptyFile);
            mockContentParser.Setup(cp => cp.Parse(It.IsAny<List<string>>())).Returns(expectedInputFile);

            //When
            luccaContentFactory.Create(aFilePath);

            //Then
            mockFileWrapper.Verify(fw => fw.Exists(aFilePath));
        }

        [Fact]
        public void GivenANonExistingFile_WhenCreateInputState_ThenRaiseError()
        {
            InputState expectedInputFile = new InputState();
            var aFilePath = "a path";
            var emptyFile = "";
            mockFileWrapper.Setup(fw => fw.Exists(It.IsAny<string>())).Returns(false);
            mockFileWrapper.Setup(fw => fw.ReadAllText(It.IsAny<string>())).Returns(emptyFile);
            mockContentParser.Setup(cp => cp.Parse(It.IsAny<List<string>>())).Returns(expectedInputFile);

            //When

            //Then
            Assert.Throws<ArgumentException>(() => luccaContentFactory.Create(aFilePath));
        }

        [Fact]
        public void GivenAFile_WhenCreateInputState_ThenRetrieveFileContent()
        {
            InputState expectedInputFile = new InputState();
            var aFilePath = "a path";
            var emptyFile = "";
            mockFileWrapper.Setup(fw => fw.Exists(It.IsAny<string>())).Returns(true);
            mockFileWrapper.Setup(fw => fw.ReadAllText(It.IsAny<string>())).Returns(emptyFile);
            mockContentParser.Setup(cp => cp.Parse(It.IsAny<List<string>>())).Returns(expectedInputFile);

            //When
            luccaContentFactory.Create(aFilePath);

            //Then
            mockFileWrapper.Verify(fw => fw.ReadAllText(aFilePath));
        }

        [Fact]
        public void GivenAnInExistingFile_WhenCreateValidInputState_ThenParseIsCalled()
        {
            //Given
            InputState expectedInputFile = new InputState();
            var anInexistingPath = "a path";
            var emptyFile = "";
            mockFileWrapper.Setup(fw => fw.Exists(It.IsAny<string>())).Returns(true);
            mockFileWrapper.Setup(fw => fw.ReadAllText(It.IsAny<string>())).Returns(emptyFile);
            mockContentParser.Setup(cp => cp.Parse(It.IsAny<List<string>>())).Returns(expectedInputFile);

            //When
            luccaContentFactory.Create(anInexistingPath);

            //Then
            mockContentParser.Verify(v => v.Parse(It.IsAny<List<string>>()));
        }
    }
}