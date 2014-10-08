using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace UmbracoAOP.EventSubscriber.Binders.ContentEvents
{
    public abstract class ContentEventBase : IEventBinder, IEventValidator
    {
        public string[] ContentTypeAliases { get; set; }
        protected string ValidSuffix { get; set; }
        protected Type ValidSenderType { get; set; }
        protected Type ValidEventArgsType { get; set; }

        public ContentEventBase(string validSuffix, Type validSenderType, Type validEventArgsType)
        {
            ValidSuffix = validSuffix;
            ValidSenderType = validSenderType;
            ValidEventArgsType = validEventArgsType;
            ContentTypeAliases = new string[] { };
        }

        abstract public void Bind(string[] contentTypeAliases, MethodInfo[] methodToBind);

        public bool Validate(string suffix, Type senderType, Type eventArgsType)
        {
            return ValidSuffix.Equals(suffix, StringComparison.OrdinalIgnoreCase) &&
                    ValidSenderType == senderType &&
                    ValidEventArgsType == eventArgsType;
        }


        abstract public IEventBinder CreateNew();
    }
}