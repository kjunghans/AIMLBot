using System;
using Xunit;
using AIMLbot;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    
    public class botTagTests : TagTester2
    {
 

        [Fact]
        public void testExpectedInput()
        {
            XmlNode testNode = getNode("<bot name= \"name\"/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.bot(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("Unknown", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testNonExistentPredicate()
        {
            XmlNode testNode = getNode("<bot name=\"nonexistent\"/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.bot(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testBadAttribute()
        {
            XmlNode testNode = getNode("<bot value=\"name\"/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.bot(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testBadNodeName()
        {
            XmlNode testNode = getNode("<bad value=\"name\"/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.bot(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testTooManyAttributes()
        {
            XmlNode testNode = getNode("<bot name=\"name\" value=\"bad\"/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.bot(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testStandardPredicateCollection()
        {
            string[] predicates = { "name", "birthday", "birthplace", "boyfriend", "favoriteband", "favoritebook", "favoritecolor", "favoritefood", "favoritesong", "favoritemovie", "forfun", "friends", "gender", "girlfriend", "kindmusic", "location", "looklike", "master", "question", "sign", "talkabout", "wear" };
            foreach(string predicate in predicates)
            {
                XmlNode testNode = getNode("<bot name=\""+predicate+"\"/>");
                var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.bot(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
                Assert.NotEqual(string.Empty, mockBotTagHandler.Transform());
            }
        }
    }
}
