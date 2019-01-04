using System;
using Xunit;
using AIMLbot;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    
    public class systemTagTests: TagTester2
    {

        [Fact]
        public void testSystemIsNotImplemented()
        {
            XmlNode testNode = getNode("<system/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.system(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }
    }
}
