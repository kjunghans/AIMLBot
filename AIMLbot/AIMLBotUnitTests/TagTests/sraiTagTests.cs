using System;
using Xunit;
using AIMLbot;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    
    public class sraiTagTests: TagTester2
    {
 
        [Fact]
        public void testSRAIWithValidInput()
        {
            XmlNode testNode = getNode("<srai>sraisucceeded</srai>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.srai(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("Test passed.", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testSRAIRecursion()
        {
            XmlNode testNode = getNode("<srai>srainested</srai>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.srai(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("Test passed.", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testSRAIEmpty()
        {
            XmlNode testNode = getNode("<srai/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.srai(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testSRAIBad()
        {
            XmlNode testNode = getNode("<srui>srainested</srui>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.srai(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }
    }
}
