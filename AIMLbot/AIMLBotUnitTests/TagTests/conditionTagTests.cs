using System;
using Xunit;
using AIMLbot;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    public class conditionTagTests : TagTester
    {
 

        [Fact]
        public void testSimpleBlockCondition()
        {
            var mockRequest = new Request("test block condition", this.mockUser, this.mockBot);
            var mockResult = this.mockBot.Chat(mockRequest);
            Assert.Equal("Test passed.", mockResult.RawOutput);
        }

        [Fact]
        public void testRecursiveBlockCondition()
        {
            var mockRequest = new Request("test block recursive call", this.mockUser, this.mockBot);
            var mockResult = this.mockBot.Chat(mockRequest);
            Assert.Equal("Test passed.", mockResult.RawOutput);
        }

        [Fact]
        public void testSingleCondition()
        {
            var mockRequest = new Request("test single condition", this.mockUser, this.mockBot);
            this.mockUser.Predicates.addSetting("test", "match1");
            var mockResult = this.mockBot.Chat(mockRequest);
            Assert.Equal("match 1 found.", mockResult.RawOutput);
            mockRequest = new Request("test single condition", this.mockUser, this.mockBot);
            this.mockUser.Predicates.addSetting("test", "match2");
            mockResult = this.mockBot.Chat(mockRequest);
            Assert.Equal("match 2 found.", mockResult.RawOutput);
            mockRequest = new Request("test single condition", this.mockUser, this.mockBot);
            this.mockUser.Predicates.addSetting("test", "match test the star works");
            mockResult = this.mockBot.Chat(mockRequest);
            Assert.Equal("match * found.", mockResult.RawOutput);
            mockRequest = new Request("test single condition", this.mockUser, this.mockBot);
            this.mockUser.Predicates.addSetting("test", "match test the star won't match this");
            mockResult = this.mockBot.Chat(mockRequest);
            Assert.Equal("default match found.", mockResult.RawOutput);
            mockRequest = new Request("test single condition", this.mockUser, this.mockBot);
            this.mockUser.Predicates.addSetting("test", "match4");
            mockResult = this.mockBot.Chat(mockRequest);
            Assert.Equal("default match found.", mockResult.RawOutput);
        }

        [Fact]
        public void testMultiCondition()
        {
            var mockRequest = new Request("test multi condition", this.mockUser, this.mockBot);
            this.mockUser.Predicates.addSetting("test1", "match1");
            var mockResult = this.mockBot.Chat(mockRequest);
            Assert.Equal("test 1 match 1 found.", mockResult.RawOutput);

            mockRequest = new Request("test multi condition", this.mockUser, this.mockBot);
            this.mockUser.Predicates.addSetting("test1", "match2");
            mockResult = this.mockBot.Chat(mockRequest);
            Assert.Equal("test 1 match 2 found.", mockResult.RawOutput);
            this.mockUser.Predicates.addSetting("test1", "");

            mockRequest = new Request("test multi condition", this.mockUser, this.mockBot);
            this.mockUser.Predicates.addSetting("test2", "match1");
            mockResult = this.mockBot.Chat(mockRequest);
            Assert.Equal("test 2 match 1 found.", mockResult.RawOutput);

            mockRequest = new Request("test multi condition", this.mockUser, this.mockBot);
            this.mockUser.Predicates.addSetting("test2", "match2");
            mockResult = this.mockBot.Chat(mockRequest);
            Assert.Equal("test 2 match 2 found.", mockResult.RawOutput);
            this.mockUser.Predicates.addSetting("test2", "");


            mockRequest = new Request("test multi condition", this.mockUser, this.mockBot);
            this.mockUser.Predicates.addSetting("test3", "match test the star works");
            mockResult = this.mockBot.Chat(mockRequest);
            Assert.Equal("match * found.", mockResult.RawOutput);
            this.mockUser.Predicates.addSetting("test3", "");


            mockRequest = new Request("test multi condition", this.mockUser, this.mockBot);
            this.mockUser.Predicates.addSetting("test3", "match test the star won't match this");
            mockResult = this.mockBot.Chat(mockRequest);
            Assert.Equal("default match found.", mockResult.RawOutput);

            mockRequest = new Request("test multi condition", this.mockUser, this.mockBot);
            this.mockUser.Predicates.addSetting("test", "match4");
            mockResult = this.mockBot.Chat(mockRequest);
            Assert.Equal("default match found.", mockResult.RawOutput);
        }

        [Fact]
        public void testSetAndCondition()
        {
            var mockRequest = new Request("TEST SET AND CONDITION", this.mockUser, this.mockBot);
            var mockResult = this.mockBot.Chat(mockRequest);
            Assert.Equal("End value: 1.", mockResult.RawOutput);
        }
    }
}
