using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoAOP.EventSubscriber
{
    /// <summary>
    /// Subscribes the method to an Umbraco Event.  
    /// The method suffix should be the event name
    /// e.g. methodName_Published ( ... )
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class UmbracoEventAttribute : Attribute
    {
        public string[] ContentTypeAliases { get; set; }

        /// <summary>
        /// Filter by target type alias
        /// </summary>
        /// <param name="targetTypeAliases"></param>
        public UmbracoEventAttribute(params string[] targetTypeAliases)
        {
            ContentTypeAliases = targetTypeAliases;
        }
    }
}