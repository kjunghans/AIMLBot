using System;
using Xunit;
using AIMLbot;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    public class javascriptTagTests: TagTester2
    {
 
        [Fact]
        public void testJavascriptIsNotImplemented()
        {
            XmlNode testNode = getNode("<javascript/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.javascript(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }
    }
}
