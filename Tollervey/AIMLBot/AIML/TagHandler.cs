using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Tollervey.AIMLBot.Utils
{
    /// <summary>
    /// Encapsulates information about a custom tag class
    /// </summary>
    public class CustomTagHandler
    {
        /// <summary>
        /// The assembly this class is found in
        /// </summary>
        public string AssemblyName;

        /// <summary>
        /// The class name for the assembly
        /// </summary>
        public string ClassName;

        /// <summary>
        /// The name of the tag this class will deal with
        /// </summary>
        public string TagName;

        /// <summary>
        /// Provides an instantiation of the class represented by this tag-handler
        /// </summary>
        /// <param name="Assemblies">All the assemblies the bot knows about</param>
        /// <returns>The instantiated class</returns>
        public AIMLTag Instantiate(Dictionary<string, Assembly> Assemblies)
        {
            if (Assemblies.ContainsKey(this.AssemblyName))
            {
                Assembly tagDLL = (Assembly)Assemblies[this.AssemblyName]; 
                return (AIMLTag)tagDLL.CreateInstance(this.ClassName);
            }
            else
            {
                return null;
            }
        }
    }
}
