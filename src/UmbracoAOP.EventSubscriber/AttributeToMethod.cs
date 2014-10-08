using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace UmbracoAOP.EventSubscriber
{
    public class AttributeToMethod
    {
        public Attribute Attribute { get; set; }

        public MethodInfo MethodInfo { get; set; }

        public AttributeToMethod(Attribute attribute, MethodInfo methodInfo)
        {
            Attribute = attribute;
            MethodInfo = methodInfo;
        }
    }
}