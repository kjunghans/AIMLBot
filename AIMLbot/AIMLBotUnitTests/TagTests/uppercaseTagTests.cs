using System;
using Xunit;
using AIMLbot;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    
    public class uppercaseTagTests: TagTester2
    {
 
        [Fact]
        public void testExpectedInput()
        {
            XmlNode testNode = getNode("<uppercase>this is a test</uppercase>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.uppercase(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("THIS IS A TEST", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testEmptyInput()
        {
            XmlNode testNode = getNode("<uppercase/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.uppercase(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }
    }
}
