using System;
using Xunit;
using AIMLbot;

namespace AIMLbot.UnitTests
{
    public class RequestTests
    {
        private AIMLbot.Bot mockBot;

        private AIMLbot.User mockUser;

        private AIMLbot.Request mockRequest;

        public RequestTests()
        {
            this.mockBot = new Bot();
            this.mockUser = new User("1", this.mockBot);
        }

        [Fact]
        public void testRequestConstructor()
        {
            mockRequest = new Request("This is a test", this.mockUser, this.mockBot);
            Assert.Equal("This is a test", mockRequest.rawInput);
        }
    }
}
