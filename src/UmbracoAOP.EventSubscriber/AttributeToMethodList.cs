using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using UmbracoAOP.EventSubscriber.Attributes.ContentEvents;

namespace UmbracoAOP.EventSubscriber
{
    public class AttributeToMethodList : List<KeyValuePair<Attribute, MethodInfo>>
    {
        public AttributeToMethodList Add(Attribute attr, MethodInfo methodInfo)
        {
            Add(new KeyValuePair<Attribute,MethodInfo>(attr, methodInfo));
            return this;
        }
    }
}