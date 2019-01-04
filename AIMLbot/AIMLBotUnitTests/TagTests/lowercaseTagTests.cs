using System;
using Xunit;
using AIMLbot;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    
    public class lowercaseTagTests: TagTester2
    {

        [Fact]
        public void testExpectedInput()
        {
            XmlNode testNode = getNode("<lowercase>THIS IS A TEST</lowercase>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.lowercase(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("this is a test", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testEmptyInput()
        {
            XmlNode testNode = getNode("<lowercase/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.lowercase(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }
    }
}
