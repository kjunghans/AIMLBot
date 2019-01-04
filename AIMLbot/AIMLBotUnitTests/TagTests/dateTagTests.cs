using System;
using Xunit;
using AIMLbot;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    public class dateTagTests : TagTester
    {

        public AIMLbot.Request mockRequest;
        public AIMLbot.Result mockResult;
        public AIMLbot.Utils.SubQuery mockQuery;

        public dateTagTests()
        {
            mockRequest = new Request("This is a test", this.mockUser, this.mockBot);
            this.mockQuery = new AIMLbot.Utils.SubQuery("This is a test <that> * <topic> *");
            this.mockQuery.InputStar.Insert(0, "first star");
            this.mockQuery.InputStar.Insert(0, "second star");
            mockResult = new Result(this.mockUser, this.mockBot, mockRequest);

        }

        [Fact]
        public void testExpectedInput()
        {
            XmlNode testNode = getNode("<date/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.date(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            DateTime now = DateTime.Now;
            DateTime expected = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            Assert.Equal(expected.ToString(this.mockBot.Locale), mockBotTagHandler.Transform());
        }

        [Fact]
        public void testBadInput()
        {
            XmlNode testNode = getNode("<dote/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.date(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("", mockBotTagHandler.Transform());
        }
    }
}
