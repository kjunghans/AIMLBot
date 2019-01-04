using System;
using Xunit;
using AIMLbot;

namespace AIMLbot.UnitTests
{
    public class ResultTests
    {
        private AIMLbot.Bot mockBot;

        private AIMLbot.User mockUser;

        private AIMLbot.Request mockRequest;

        private AIMLbot.Result mockResult;

        public ResultTests()
        {
            this.mockBot = new Bot();
            this.mockUser = new User("1", this.mockBot);
            mockRequest = new Request("This is a test", this.mockUser, this.mockBot);
        }

        [Fact]
        public void testConstructor()
        {
            mockResult = new Result(this.mockUser, this.mockBot, mockRequest);
            Assert.Equal("This is a test", mockResult.RawInput);
        }
    }
}
