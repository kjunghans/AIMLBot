using System;
using Xunit;
using AIMLbot;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    
    public class srTagTests: TagTester2
    {
  
        [Fact]
        public void testSRAIWithValidInput()
        {
            XmlNode testNode = getNode("<sr/>");
            this.mockQuery.InputStar.Insert(0,"sraisucceeded");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.sr(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("Test passed.", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testSRAIRecursion()
        {
            XmlNode testNode = getNode("<sr/>");
            this.mockQuery.InputStar.Insert(0,"srainested");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.sr(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("Test passed.", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testSRAIEmpty()
        {
            XmlNode testNode = getNode("<sr/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.sr(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testSRAIBad()
        {
            XmlNode testNode = getNode("<se/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.sr(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }
    }
}
