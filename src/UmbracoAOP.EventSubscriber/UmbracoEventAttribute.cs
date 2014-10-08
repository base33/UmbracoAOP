using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoAOP.EventSubscriber
{
    /// <summary>
    /// Subscribes the method to an Umbraco Event
    /// Use _ and the event
    /// e.g. methodName_Published ( ... )
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class UmbracoEventAttribute : Attribute
    {
        public string[] ContentTypeAliases { get; set; }

        public UmbracoEventAttribute(params string[] contentTypeAliases)
        {
            ContentTypeAliases = contentTypeAliases;
        }
    }
}