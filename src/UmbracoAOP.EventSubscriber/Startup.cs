using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmbracoAOP.EventSubscriber;
using UmbracoAOP.EventSubscriber.Binders;
using UmbracoAOP.EventSubscriber.Binders.ContentEvents;
using umbraco.cms.businesslogic;
using umbraco.cms.businesslogic.web;
using Umbraco.Core;
using System.Diagnostics;
using Umbraco.Core.Services;
using System.Reflection;

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

            //bind attributes that require no values
            var attributeToMethodList = ReflectionHelper.GetMethodsWithAttribute(typeof(UmbracoEventAttribute));


            var eventBindingsLookup = new EventBindingsLookup();

            foreach (var attributeToMethod in attributeToMethodList)
            {
                var eventBinder = eventBindingsLookup.LookUpValidEventBinder(attributeToMethod.MethodInfo);
                if (eventBinder != null)
                    eventBinder(attributeToMethod.MethodInfo, (UmbracoEventAttribute)attributeToMethod.Attribute);
            }

            sw.Stop();
            Debug.WriteLine(sw.Elapsed);
        }
    }
}