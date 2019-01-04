using System;
using Xunit;
using AIMLbot;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    
    public class sentenceTagTests: TagTester2
    {
 
        [Fact]
        public void testNonAtomicUpper()
        {
            XmlNode testNode = getNode("<sentence>THIS IS. A TEST TO? SEE IF THIS; WORKS! OK</sentence>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.sentence(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("This is. A test to? See if this; Works! Ok", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testNonAtomicLower()
        {
            XmlNode testNode = getNode("<sentence>this is. a test to? see if this; works! ok</sentence>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.sentence(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("This is. A test to? See if this; Works! Ok", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testAtomic()
        {
            XmlNode testNode = getNode("<sentence/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.sentence(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            this.mockQuery.InputStar.Insert(0, "THIS IS. A TEST TO? SEE IF THIS; WORKS! OK");
            Assert.Equal("This is. A test to? See if this; Works! Ok", mockBotTagHandler.Transform());
        }

        [Fact]
        public void testEmptyInput()
        {
            XmlNode testNode = getNode("<sentence/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.sentence(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            this.mockQuery.InputStar.Clear();
            Assert.Equal("", mockBotTagHandler.Transform());
        }
    }
}
