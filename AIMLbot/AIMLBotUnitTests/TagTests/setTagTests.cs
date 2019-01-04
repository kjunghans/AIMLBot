using System;
using Xunit;
using AIMLbot;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    
    public class setTagTests: TagTester2
    {

        [Fact]
        public void testWithGoodData()
        {
            XmlNode testNode = getNode("<set name=\"test1\">content 1</set>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.set(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("content 1", mockBotTagHandler.Transform());
            Assert.True(this.mockUser.Predicates.containsSettingCalled("test1"));
        }

        [Fact]
        public void testAbilityToRemovePredicates()
        {
            XmlNode testNode = getNode("<set name=\"test1\">content 1</set>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.set(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("content 1", mockBotTagHandler.Transform());
            Assert.True(this.mockUser.Predicates.containsSettingCalled("test1"));
            XmlNode testNode2 = getNode("<set name=\"test1\"/>");
            mockBotTagHandler = new AIMLbot.AIMLTagHandlers.set(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode2);
            Assert.Equal("", mockBotTagHandler.Transform());
            Assert.False(this.mockUser.Predicates.containsSettingCalled("test1"));
        }

        [Fact]
        public void testWithBadNode()
        {
            XmlNode testNode = getNode("<sot name=\"test2\">content 2</sot>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.set(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testWithBadAttribute()
        {
            XmlNode testNode = getNode("<set nome=\"test 3\">content 3</set>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.set(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testWithTooManyAttributes()
        {
            XmlNode testNode = getNode("<set name=\"test 4\" value=\"value\" >content 4</set>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.set(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testWithNoAttributes()
        {
            XmlNode testNode = getNode("<set/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.set(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }
    }
}
