using System;
using Xunit;
using AIMLbot;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    
    public class thatTagTests: TagTester
    {

        [Fact]
        public void testResultHandlers()
        {
            XmlNode testNode = getNode("<that/>");
            var mockQuery = new AIMLbot.Utils.SubQuery("This is a test <that> * <topic> *");
            mockQuery.InputStar.Insert(0, "first star");
            mockQuery.InputStar.Insert(0, "second star");
            var mockRequest = new Request("Sentence 1. Sentence 2", this.mockUser, this.mockBot);
            var mockResult = new Result(this.mockUser, this.mockBot, mockRequest);
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.that(this.mockBot, this.mockUser, mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
            mockResult.OutputSentences.Add("Result 1");
            mockResult.OutputSentences.Add("Result 2");
            this.mockUser.addResult(mockResult);
            Result mockResult2 = new Result(this.mockUser, this.mockBot, mockRequest);
            mockResult2.OutputSentences.Add("Result 3");
            mockResult2.OutputSentences.Add("Result 4");
            this.mockUser.addResult(mockResult2);

            Assert.Equal("Result 3", mockBotTagHandler.Transform());

            testNode = getNode("<that index=\"1\"/>");
            mockBotTagHandler = new AIMLbot.AIMLTagHandlers.that(this.mockBot, this.mockUser, mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("Result 3", mockBotTagHandler.Transform());

            testNode = getNode("<that index=\"2,1\"/>");
            mockBotTagHandler = new AIMLbot.AIMLTagHandlers.that(this.mockBot, this.mockUser, mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("Result 1", mockBotTagHandler.Transform());

            testNode = getNode("<that index=\"1,2\"/>");
            mockBotTagHandler = new AIMLbot.AIMLTagHandlers.that(this.mockBot, this.mockUser, mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("Result 4", mockBotTagHandler.Transform());

            testNode = getNode("<that index=\"2,2\"/>");
            mockBotTagHandler = new AIMLbot.AIMLTagHandlers.that(this.mockBot, this.mockUser, mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("Result 2", mockBotTagHandler.Transform());

            testNode = getNode("<that index=\"1,3\"/>");
            mockBotTagHandler = new AIMLbot.AIMLTagHandlers.that(this.mockBot, this.mockUser, mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());

            testNode = getNode("<that index=\"3\"/>");
            mockBotTagHandler = new AIMLbot.AIMLTagHandlers.that(this.mockBot, this.mockUser, mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }
    }
}
