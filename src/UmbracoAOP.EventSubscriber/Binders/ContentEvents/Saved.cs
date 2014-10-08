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
        /// <para>Raised after a content is saved</para>
        /// <para>Signature: <bold>foo(IContentService sender, SaveEventArgs&lt;IContent&gt; e)</bold></para>
        /// </summary>
        /// <remarks></remarks>
        /// <code>MethodName(IContentService sender, SaveEventArgs&lt;IContent&gt; e)</code>
        public class Saved : ContentEventBase
        {
            protected MethodInfo[] MethodsToBind { get; set; }

            public Saved() : base("Saved", typeof(IContentService), typeof(SaveEventArgs<IContent>)) { }

            public override IEventBinder CreateNew()
            {
                return new Saved();
            }

            public override void Bind(string[] contentTypeAliases, MethodInfo[] methodsToBind)
            {

                if (contentTypeAliases.Length > 0)
                {
                    //bind with filter
                    MethodsToBind = methodsToBind;
                    ContentService.Saved += FilterEvent;
                    ContentTypeAliases = contentTypeAliases;
                }
                else
                {
                    //bind without filter
                    var eventBinder = new EventBinder();
                    foreach(var methodToBind in methodsToBind)
                        eventBinder.BindToEvent(typeof(ContentService), "Saved", methodToBind);
                }
            }

            public void FilterEvent(IContentService sender, Umbraco.Core.Events.SaveEventArgs<Umbraco.Core.Models.IContent> e)
            {
                //check if this is a valid content type
                if (e.SavedEntities.Select(c => c.ContentType.Alias).Intersect(ContentTypeAliases).Count() > 0)
                {
                    foreach (var methodToBind in MethodsToBind)
                        methodToBind.Invoke(null, new object[] { sender, e });
                }
            }
        }
    }
}