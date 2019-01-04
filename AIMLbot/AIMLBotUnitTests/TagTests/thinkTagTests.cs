using System;
using Xunit;
using AIMLbot;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    
    public class thinkTagTests: TagTester2
    {

        [Fact]
        public void testExpectedInput()
        {
            XmlNode testNode = getNode("<think>This is a test</think>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.think(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testAsPartOfLargerTemplate()
        {
            this.mockBot.loadAIMLFromFiles();
            Result newResult = this.mockBot.Chat("test think", "1");
            Assert.Equal("You should see this.", newResult.RawOutput);
        }

        [Fact]
        public void testWithChildNodes()
        {
            this.mockBot.loadAIMLFromFiles();
            Result newResult = this.mockBot.Chat("test child think", "1");
            Assert.Equal("You should see this.", newResult.RawOutput);
            Assert.Equal("GOSSIP from user: 1, 'some gossip'",this.mockBot.LastLogMessage);
        }
    }
}
