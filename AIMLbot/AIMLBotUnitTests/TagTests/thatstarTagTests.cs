using System;
using Xunit;
using AIMLbot;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    
    public class thatstarTagTests: TagTester2
    {
 
        [Fact]
        public void testAtomic()
        {
            XmlNode testNode = getNode("<thatstar/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.thatstar(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("second star", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testIndexed()
        {
            XmlNode testNode = getNode("<thatstar index=\"1\"/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.thatstar(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("second star", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testIndexed2()
        {
            XmlNode testNode = getNode("<thatstar index=\"2\"/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.thatstar(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("first star", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testOutOfBounds()
        {
            XmlNode testNode = getNode("<thatstar index=\"3\"/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.thatstar(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testBadIndex()
        {
            XmlNode testNode = getNode("<thatstar index=\"two\"/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.thatstar(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }
    }
}
