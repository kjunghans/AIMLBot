using System;
using Xunit;
using AIMLbot;
using System.Xml;
using System.Collections.Generic;

namespace AIMLbot.UnitTests.TagTests
{
    
    public class randomTagTests: TagTester2
    {
        private List<string> possibleResults;
        public randomTagTests()
        {
            this.possibleResults = new List<string>();
            this.possibleResults.Add("random 1");
            this.possibleResults.Add("random 2");
            this.possibleResults.Add("random 3");
            this.possibleResults.Add("random 4");
            this.possibleResults.Add("random 5");

        }

        [Fact]
        public void testWithValidData()
        {
            XmlNode testNode = getNode(@"<random>
    <li>random 1</li>
    <li>random 2</li>
    <li>random 3</li>
    <li>random 4</li>
    <li>random 5</li>
</random>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.random(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Contains(mockBotTagHandler.Transform(), this.possibleResults);
        }

        [Fact]
        public void testWithBadListItems()
        {
            XmlNode testNode = getNode(@"<random>
    <li>random 1</li>
    <bad>bad 1</bad>
    <li>random 2</li>
    <bad>bad 2</bad>
    <li>random 3</li>
    <bad>bad 3</bad>
    <li>random 4</li>
    <bad>bad 4</bad>
    <li>random 5</li>
    <bad>bad 5</bad>
</random>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.random(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Contains(mockBotTagHandler.Transform(), this.possibleResults);
        }

        [Fact]
        public void testWithNoListItems()
        {
            XmlNode testNode = getNode("<random/>");
            var mockBotTagHandler = new AIMLbot.AIMLTagHandlers.random(this.mockBot, this.mockUser, this.mockQuery, mockRequest, mockResult, testNode);
            Assert.Equal("",mockBotTagHandler.Transform());
        }
    }
}
