using System;
using System.Text;
using AIMLbot.Utils;

namespace AIMLbot.Example.CustomTags
{
    [CustomTag]
    public class system : AIMLTagHandler
    {
        public system()
        {
            this.inputString = "testtag";
        }

        protected override string ProcessChange()
        {
            if (this.templateNode.Name.ToLower() == "system")
            {
                return "Override default tag implementation works correctly";
            }
            return string.Empty;
        }
    }
}
