using System;
using Xunit;
using AIMLbot;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    public class gossipTagTests : TagTester2
    {
 
        [Fact]
        public void testGossipWithGoodData()
        {
            XmlNode testNode = getNode("<gossip>this is gossip</gossip>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.gossip(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            mockBotTagHandler.Transform();
            Assert.Equal("GOSSIP from user: 1, 'this is gossip'", this.mockBot.LastLogMessage);
        }

        [Fact]
        public void testGossipWithEmpty()
        {
            XmlNode testNode = getNode("<gossip/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.gossip(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            mockBotTagHandler.Transform();
            Assert.Equal("", this.mockBot.LastLogMessage);
        }
    }
}
