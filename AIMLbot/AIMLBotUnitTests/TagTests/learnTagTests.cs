using System;
using Xunit;
using AIMLbot;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    public class learnTagTests: TagTester2
    {

        [Fact]
        public void testWithValidInput()
        {
            Assert.Equal(0, this.mockBot.Size);
            XmlNode testNode = getNode("<learn>./aiml/Salutations.aiml</learn>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.learn(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
            Assert.Equal(16, this.mockBot.Size);
        }

        [Fact]
        public void testWithBadInput()
        {

            Assert.Equal(0, this.mockBot.Size);
            XmlNode testNode = getNode("<learn>./nonexistent/Salutations.aiml</learn>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.learn(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
            Assert.Equal(0, this.mockBot.Size);
        }

        [Fact]
        public void testWithEmptyInput()
        {

            Assert.Equal(0, this.mockBot.Size);
            XmlNode testNode = getNode("<learn/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.learn(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
            Assert.Equal(0, this.mockBot.Size);
        }
    }
}
