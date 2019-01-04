using System;
using Xunit;
using AIMLbot;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    public class genderTagTests : TagTester2
    {
 
        [Fact]
        public void testNonAtomic()
        {
            XmlNode testNode = getNode("<gender> HE SHE TO HIM FOR HIM WITH HIM ON HIM IN HIM TO HER FOR HER WITH HER ON HER IN HER HIS HER HIM </gender>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.gender(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal(" she he to her for her with her on her in her to him for him with him on him in him her his her ", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testAtomic()
        {
            XmlNode testNode = getNode("<gender/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.gender(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            this.mockQuery.InputStar.Insert(0, " HE SHE TO HIM TO HER HIS HER HIM ");
            Assert.Equal(" she he to her to him her his her ", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testEmptyInput()
        {
            XmlNode testNode = getNode("<gender/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.gender(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            this.mockQuery.InputStar.Clear();
            Assert.Equal("", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testNoMatches()
        {
            XmlNode testNode = getNode("<gender>THE QUICK BROWN FOX JUMPED OVER THE LAZY DOGS</gender>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.gender(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("THE QUICK BROWN FOX JUMPED OVER THE LAZY DOGS", mockBotTagHandler.Transform());
        }
    }
}
