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
        /// <para>Fired after the content object has been copied.</para>
        /// <para>Signature: <bold>foo(IContentService sender, Umbraco.Core.Events.CopyEventArgs&lt;IContent&gt; e)</bold></para>
        /// </summary>
        /// <remarks></remarks>
        /// <code>MethodName(IContentService sender, Umbraco.Core.Events.CopyEventArgs&lt;IContent&gt; e)</code>
        public class Copied : ContentEventBase
        {
            protected MethodInfo[] MethodsToBind { get; set; }

            public Copied() : base("Copied", typeof(IContentService), typeof(EventArgs)) { }

            public override IEventBinder CreateNew()
            {
                return new Copied();
            }

            public override void Bind(string[] contentTypeAliases, MethodInfo[] methodsToBind)
            {

                if (contentTypeAliases.Length > 0)
                {
                    //bind with filter
                    MethodsToBind = methodsToBind;
                    ContentTypeAliases = contentTypeAliases;
                    ContentService.Copied += FilterEvent;
                }
                else
                {
                    //bind without filter
                    var eventBinder = new EventBinder();
                    foreach (MethodInfo methodToBind in methodsToBind)
                        eventBinder.BindToEvent(typeof(ContentService), "Copied", methodToBind);
                }
            }

            void FilterEvent(IContentService sender, CopyEventArgs<IContent> e)
            {
                //check if this is a valid content type
                if (ContentTypeAliases.Contains(e.Original.ContentType.Alias))
                {
                    foreach (var methodToBind in MethodsToBind)
                        methodToBind.Invoke(null, new object[] { sender, e });
                }
            }
        }
    }
}