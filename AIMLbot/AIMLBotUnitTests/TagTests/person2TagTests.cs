using System;
using Xunit;
using AIMLbot;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    
    public class person2TagTests: TagTester2
    {

        [Fact]
        public void testNonAtomic()
        {
            XmlNode testNode = getNode("<person2> WITH YOU TO YOU ME MY YOUR </person2>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.person2(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal(" with me to me you your my ", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testAtomic()
        {
            XmlNode testNode = getNode("<person2/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.person2(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            this.mockQuery.InputStar.Insert(0, " WITH YOU TO YOU ME MY YOUR ");
            Assert.Equal(" with me to me you your my ", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testEmptyInput()
        {
            XmlNode testNode = getNode("<person2/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.person2(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            this.mockQuery.InputStar.Clear();
            Assert.Equal("", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testNoMatches()
        {
            XmlNode testNode = getNode("<person2>THE QUICK BROWN FOX JUMPED OVER THE LAZY DOGS</person2>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.person2(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("THE QUICK BROWN FOX JUMPED OVER THE LAZY DOGS", mockBotTagHandler.Transform());
        }
    }
}
