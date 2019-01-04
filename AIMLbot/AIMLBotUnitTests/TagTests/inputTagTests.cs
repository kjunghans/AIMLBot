using System;
using Xunit;
using AIMLbot;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    public class inputTagTests: TagTester2
    {
 
        [Fact]
        public void testResultHandlers()
        {
            XmlNode testNode = getNode("<input/>");
            Result mockResult = new Result(this.mockUser, this.mockBot, mockRequest);
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.input(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
            mockRequest = new Request("Sentence 1. Sentence 2", this.mockUser, this.mockBot);
            mockResult.InputSentences.Add("Result 1");
            mockResult.InputSentences.Add("Result 2");
            this.mockUser.addResult(mockResult);
            Result mockResult2 = new Result(this.mockUser, this.mockBot, mockRequest);
            mockResult2.InputSentences.Add("Result 3");
            mockResult2.InputSentences.Add("Result 4");
            this.mockUser.addResult(mockResult2);

            Assert.Equal("Result 3", mockBotTagHandler.Transform());

            testNode = getNode("<input index=\"1\"/>");
            mockBotTagHandler = new AIMLbot.AIMLTagHandlers.input(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("Result 3", mockBotTagHandler.Transform());

            testNode = getNode("<input index=\"2,1\"/>");
            mockBotTagHandler = new AIMLbot.AIMLTagHandlers.input(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("Result 1", mockBotTagHandler.Transform());

            testNode = getNode("<input index=\"1,2\"/>");
            mockBotTagHandler = new AIMLbot.AIMLTagHandlers.input(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("Result 4", mockBotTagHandler.Transform());

            testNode = getNode("<input index=\"2,2\"/>");
            mockBotTagHandler = new AIMLbot.AIMLTagHandlers.input(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("Result 2", mockBotTagHandler.Transform());

            testNode = getNode("<input index=\"1,3\"/>");
            mockBotTagHandler = new AIMLbot.AIMLTagHandlers.input(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());

            testNode = getNode("<input index=\"3\"/>");
            mockBotTagHandler = new AIMLbot.AIMLTagHandlers.input(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }
    }
}
