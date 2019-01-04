using System;
using Xunit;
using AIMLbot;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    public class getTagTests : TagTester2
    {


        [Fact]
        public void testWithGoodData()
        {
            // first element
            XmlNode testNode = getNode("<get name=\"name\"/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.get(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("un-named user", mockBotTagHandler.Transform());

            // last element
            testNode = getNode("<get name=\"we\"/>");
            mockBotTagHandler = new AIMLbot.AIMLTagHandlers.get(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("unknown", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testWithNonExistentPredicate()
        {
            XmlNode testNode = getNode("<get name=\"nonexistent\"/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.get(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testWithBadNode()
        {
            XmlNode testNode = getNode("<got name=\"we\"/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.get(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testWithBadAttribute()
        {
            XmlNode testNode = getNode("<get nome=\"we\"/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.get(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testWithTooManyAttributes()
        {
            XmlNode testNode = getNode("<get name=\"we\" value=\"value\" />");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.get(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testWithNoAttributes()
        {
            XmlNode testNode = getNode("<get/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.get(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }
    }
}
