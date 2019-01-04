using System;
using System.Xml;
using AIMLbot.Utils; 

namespace AIMLbot.Example.CustomTags
{
    /// <summary>
    /// Uses a web-service (found at www.fullerdata.com) to display a fortune cookie 
    /// </summary>
    [CustomTag]
    public class fortunecookie : AIMLTagHandler
    {
        public fortunecookie()
        {
            this.inputString = "fortunecookie";
        }

        protected override string ProcessChange()
        {
            if (this.templateNode.Name.ToLower() == "fortunecookie")
            {
                //TODO: find another web service for example
                //com.fullerdata.www.FullerDataFortuneCookie fc = new ExampleCustomAIMLTags.com.fullerdata.www.FullerDataFortuneCookie();
                //string fortune = fc.GetFortuneCookie();
                //return fortune;
                return "You will have good fortune";
            }
            return string.Empty;
        }
    }
}
