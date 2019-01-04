using System;
using Xunit;
using AIMLbot;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    
    public class personTagTests: TagTester2
    {
 
        [Fact]
        public void testNonAtomic()
        {
            XmlNode testNode = getNode("<person> I WAS HE WAS SHE WAS I AM I ME MY MYSELF </person>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.person(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal(" he or she was I was I was he or she is he or she him or her his or her him or herself ", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testAtomic()
        {
            XmlNode testNode = getNode("<person/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.person(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            this.mockQuery.InputStar.Insert(0, " I WAS HE WAS SHE WAS I AM I ME MY MYSELF ");
            Assert.Equal(" he or she was I was I was he or she is he or she him or her his or her him or herself ", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testEmptyInput()
        {
            XmlNode testNode = getNode("<person/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.person(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            this.mockQuery.InputStar.Clear();
            Assert.Equal("", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testNoMatches()
        {
            XmlNode testNode = getNode("<person>THE QUICK BROWN FOX JUMPED OVER THE LAZY DOGS</person>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.person(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("THE QUICK BROWN FOX JUMPED OVER THE LAZY DOGS", mockBotTagHandler.Transform());
        }
    }
}
