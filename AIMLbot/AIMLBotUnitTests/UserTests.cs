using System;
using Xunit;
using AIMLbot;

namespace AIMLbot.UnitTests
{
    public class UserTests
    {
        private AIMLbot.Bot mockBot;

        private AIMLbot.User mockUser;

        public  UserTests()
        {
            this.mockBot = new Bot();
        }

        [Fact]
        public void testConstructorPopulatesUserObject()
        {
            this.mockUser = new User("1", this.mockBot);
            Assert.Equal("*", this.mockUser.Topic);
            Assert.Equal("1", this.mockUser.UserID);
            // the +1 in the following assert is the creation of the default topic predicate
            Assert.Equal(this.mockBot.DefaultPredicates.SettingNames.Length+1, this.mockUser.Predicates.SettingNames.Length);
        }

        [Fact]
        public void testBadConstructor()
        {
            Action act = () => this.mockUser = new User("", this.mockBot);
            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void testResultHandlers()
        {
            this.mockUser = new User("1", this.mockBot);
            Assert.Equal("", this.mockUser.getResultSentence());
            Request mockRequest = new Request("Sentence 1. Sentence 2",this.mockUser,this.mockBot);
            Result mockResult = new Result(this.mockUser, this.mockBot, mockRequest);
            mockResult.InputSentences.Add("Result 1");
            mockResult.InputSentences.Add("Result 2");
            mockResult.OutputSentences.Add("Result 1");
            mockResult.OutputSentences.Add("Result 2");
            this.mockUser.addResult(mockResult);
            Result mockResult2 = new Result(this.mockUser, this.mockBot, mockRequest);
            mockResult2.InputSentences.Add("Result 3");
            mockResult2.InputSentences.Add("Result 4");
            mockResult2.OutputSentences.Add("Result 3");
            mockResult2.OutputSentences.Add("Result 4");
            this.mockUser.addResult(mockResult2);
            Assert.Equal("Result 3", this.mockUser.getResultSentence());
            Assert.Equal("Result 3", this.mockUser.getResultSentence(0));
            Assert.Equal("Result 1", this.mockUser.getResultSentence(1));
            Assert.Equal("Result 4", this.mockUser.getResultSentence(0, 1));
            Assert.Equal("Result 2", this.mockUser.getResultSentence(1, 1));
            Assert.Equal("", this.mockUser.getResultSentence(0, 2));
            Assert.Equal("", this.mockUser.getResultSentence(2, 0));            
            Assert.Equal("Result 3", this.mockUser.getThat());
            Assert.Equal("Result 3", this.mockUser.getThat(0));
            Assert.Equal("Result 1", this.mockUser.getThat(1));
            Assert.Equal("Result 4", this.mockUser.getThat(0, 1));
            Assert.Equal("Result 2", this.mockUser.getThat(1, 1));
            Assert.Equal("", this.mockUser.getThat(0, 2));
            Assert.Equal("", this.mockUser.getThat(2, 0));
        }
    }
}
