using System;
using Xunit;
using AIMLbot;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    public class idTagTests: TagTester2
    {
         [Fact]
        public void testWithValidData()
        {
            XmlNode testNode = getNode("<id/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.id(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("1", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testWithBadXml()
        {
            XmlNode testNode = getNode("<od/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.id(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }
    }
}
