using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace AIMLbot.UnitTests.TagTests
{
    public class TagTester
    {
        public AIMLbot.Bot mockBot;
        public AIMLbot.User mockUser;
        //public AIMLbot.Request mockRequest;
        //public AIMLbot.Result mockResult;
        //public AIMLbot.Utils.SubQuery mockQuery;

        public TagTester()
        {
            this.mockBot = new Bot();
            this.mockBot.loadSettings();
            this.mockBot.loadAIMLFromFiles();
            this.mockUser = new User("1", this.mockBot);
            //mockRequest = new Request("This is a test", this.mockUser, this.mockBot);
            //this.mockQuery = new AIMLbot.Utils.SubQuery("This is a test <that> * <topic> *");
            //this.mockQuery.InputStar.Insert(0, "first star");
            //this.mockQuery.InputStar.Insert(0, "second star");
            //mockResult = new Result(this.mockUser, this.mockBot, mockRequest);
        }

        public  XmlNode getNode(string outerXML)
        {
            XmlDocument temp = new XmlDocument();
            temp.LoadXml(outerXML);
            return temp.FirstChild;
        }

    }
}
