using System;
using Xunit;
using AIMLbot;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    
    public class versionTagTests: TagTester2
    {

        [Fact]
        public void testExpectedInput()
        {
            XmlNode testNode = getNode("<version/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.version(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("Unknown", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testBadInput()
        {
            XmlNode testNode = getNode("<vorsion/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.version(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }
    }
}
