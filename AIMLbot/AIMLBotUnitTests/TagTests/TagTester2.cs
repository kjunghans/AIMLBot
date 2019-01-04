using AIMLbot;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIMLbot.UnitTests.TagTests
{
    public class TagTester2: TagTester
    {
        public AIMLbot.Request mockRequest;
        public AIMLbot.Result mockResult;
        public AIMLbot.Utils.SubQuery mockQuery;

        public TagTester2()
        {
            mockRequest = new Request("This is a test", this.mockUser, this.mockBot);
            this.mockQuery = new AIMLbot.Utils.SubQuery("This is a test <that> * <topic> *");
            this.mockQuery.InputStar.Insert(0, "first star");
            this.mockQuery.InputStar.Insert(0, "second star");
            mockResult = new Result(this.mockUser, this.mockBot, mockRequest);

        }

    }
}
