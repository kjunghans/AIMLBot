using System;
using Xunit;
using AIMLbot;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    
    public class starTagTests: TagTester2
    {

        [Fact]
        public void testExpectedInput()
        {
            XmlNode testNode = getNode("<star/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.star(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("second star", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testExpectedInputIndex()
        {
            XmlNode testNode = getNode("<star index=\"1\"/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.star(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("second star", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testExpectedInputIndexSecond()
        {
            XmlNode testNode = getNode("<star index=\"2\"/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.star(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("first star", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testExpectedInputIndexOutOfBounds()
        {
            XmlNode testNode = getNode("<star index=\"3\"/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.star(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testBadInputAttributeName()
        {
            XmlNode testNode = getNode("<star indox=\"3\"/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.star(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testBadInputAttributeValue()
        {
            XmlNode testNode = getNode("<star index=\"one\"/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.star(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testBadInputTagName()
        {
            XmlNode testNode = getNode("<stor index=\"1\"/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.star(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }
    }
}
