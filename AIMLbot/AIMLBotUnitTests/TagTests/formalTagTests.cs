using System;
using Xunit;
using AIMLbot;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    public class formalTagTests : TagTester2
    {
 
        [Fact]
        public void testExpectedInput()
        {
            XmlNode testNode = getNode("<formal>this is a test</formal>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.formal(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("This Is A Test", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testExpectedCapitalizedInput()
        {
            XmlNode testNode = getNode("<formal>THIS IS A TEST</formal>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.formal(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("This Is A Test", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testEmptyInput()
        {
            XmlNode testNode = getNode("<formal/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.formal(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }
    }
}
