using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using umbraco.cms.businesslogic.web;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace UmbracoAOP.EventSubscriber.Binders.ContentEvents
{
    public static partial class ContentEvent
    {
        /// <summary>
        /// <para>Fired after a copy object has been created and had its parentId updated and its state has been set to unpublished.</para>
        /// <para>Signature: <bold>foo(IContentService sender, Umbraco.Core.Events.CopyEventArgs&lt;IContent&gt; e)</bold></para>
        /// </summary>
        /// <remarks></remarks>
        /// <code>MethodName(IContentService sender, Umbraco.Core.Events.CopyEventArgs&lt;IContent&gt; e)</code>
        public class Copying : ContentEventBase
        {
            protected MethodInfo[] MethodsToBind { get; set; }

            public Copying() : base("Copying", typeof(IContentService), typeof(CopyEventArgs<IContent>)) { }

            public override IEventBinder CreateNew()
            {
                return new Copying();
            }

            
            public override void Bind(string[] contentTypeAliases, MethodInfo[] methodsToBind)
            {

                if (contentTypeAliases.Length > 0)
                {
                    //bind with filter
                    MethodsToBind = methodsToBind;
                    ContentTypeAliases = contentTypeAliases;
                    ContentService.Copying += FilterEvent;
                }
                else
                {
                    //bind without filter
                    var eventBinder = new EventBinder();
                    foreach(var methodToBind in methodsToBind)
                        eventBinder.BindToEvent(typeof(ContentService), "Copying", methodToBind);
                }
            }

            void FilterEvent(IContentService sender, Umbraco.Core.Events.CopyEventArgs<IContent> e)
            {
                //check if this is a valid content type
                if (ContentTypeAliases.Contains(e.Original.ContentType.Alias))
                {
                    foreach(var methodToBind in MethodsToBind)
                        methodToBind.Invoke(null, new object[] { sender, e });
                }
            }
        }
    }
}