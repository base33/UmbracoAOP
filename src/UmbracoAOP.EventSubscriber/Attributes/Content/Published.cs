using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using umbraco.cms.businesslogic.web;
using Umbraco.Core.Models;
using Umbraco.Core.Publishing;
using Umbraco.Core.Services;

namespace UmbracoAOP.EventSubscriber.Attributes.ContentEvents
{
    public static partial class ContentEvent
    {
        /// <summary>
        /// <para>Raised after Content is published</para>
        /// <para>Signature: <bold>foo(IPublishingStrategy sender, Umbraco.Core.Events.PublishEventArgs&lt;IContent&gt; e)</bold></para>
        /// </summary>
        /// <remarks></remarks>
        /// <code>MethodName(IPublishingStrategy sender, Umbraco.Core.Events.PublishEventArgs&lt;IContent&gt; e)</code>
        [AttributeUsage(AttributeTargets.Method)]
        public class Published : Attribute, IBindToEvent
        {
            /// <summary>
            /// Content Type Alias to filter (if specified)
            /// </summary>
            public string[] ContentTypeAliases { get; set; }

            /// <summary>
            /// Methods to bind - used in the event filter
            /// </summary>
            protected MethodInfo MethodToBind { get; set; }

            public Published() { ContentTypeAliases = new string[] {}; }

            /// <summary>
            /// Filter by Content Type Aliases
            /// </summary>
            /// <param name="contentTypeAlias"></param>
            public Published(params string[] contentTypeAliases)
            {
                ContentTypeAliases = contentTypeAliases;
            }

            /// <summary>
            /// Binds the method to the event
            /// </summary>
            /// <param name="methodToBind"></param>
            public void Bind(MethodInfo methodToBind)
            {
                
                if (ContentTypeAliases.Length > 0)
                {
                    //bind with filter
                    MethodToBind = methodToBind;
                    ContentService.Published += FilterEvent;
                }
                else
                {
                    //bind without filter
                    var eventBinder = new EventBinder();
                    eventBinder.BindToEvent(typeof(ContentService), "Published", methodToBind);
                }
            }

            public void FilterEvent(IPublishingStrategy sender, Umbraco.Core.Events.PublishEventArgs<Umbraco.Core.Models.IContent> e)
            {
                //check if this is a valid content type
                if (e.PublishedEntities.Select(c => c.ContentType.Alias).Intersect(ContentTypeAliases).Count() > 0)
                {
                    MethodToBind.Invoke(null, new object[] { sender, e });
                }
            }
        }
    }
}