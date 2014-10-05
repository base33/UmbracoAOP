using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmbracoAOP.EventSubscriber;
using UmbracoAOP.EventSubscriber.Attributes;
using UmbracoAOP.EventSubscriber.Attributes.ContentEvents;
using umbraco.cms.businesslogic;
using umbraco.cms.businesslogic.web;
using Umbraco.Core;
using System.Diagnostics;
using Umbraco.Core.Services;

namespace UmbracoAOP.EventSubscriber
{
    public class Startup : ApplicationEventHandler
    {
        public Startup()
        {
            Start();
        }

        public static void Start()
        {
            var sw = new Stopwatch();
            sw.Start();

            var umbracoEventsProvider = new UmbracoEventAttributeProvider();
            Type[] eventAttributes = umbracoEventsProvider.Get();

            //bind attributes that require no values
            AttributeToMethodList methodAttrMapping = ReflectionHelper.GetMethodsWithAttribute(eventAttributes);
            foreach (var attrMapping in methodAttrMapping)
            {
                var binder = (IBindToEvent) attrMapping.Key;
                binder.Bind(attrMapping.Value);
            }

            sw.Stop();
            Debug.WriteLine(sw.Elapsed);
        }
    }
}