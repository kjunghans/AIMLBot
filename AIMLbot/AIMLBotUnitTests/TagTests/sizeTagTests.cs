using System;
using Xunit;
using AIMLbot;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    
    public class sizeTagTests: TagTester2
    {
        public static int Size = 30;

        [Fact]
        public void testWithValidData()
        {
            XmlNode testNode = getNode("<size/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.size(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("0", mockBotTagHandler.Transform());
            AIMLbot.Utils.AIMLLoader loader = new AIMLbot.Utils.AIMLLoader(this.mockBot);
            loader.loadAIML();
            Assert.Equal(Convert.ToString(sizeTagTests.Size), mockBotTagHandler.Transform());
        }

        [Fact]
        public void testWithBadXml()
        {
            XmlNode testNode = getNode("<soze/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.size(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }
    }
}
