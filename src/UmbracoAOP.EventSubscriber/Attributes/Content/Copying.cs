﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using umbraco.cms.businesslogic.web;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace UmbracoAOP.EventSubscriber.Attributes.ContentEvents
{
    public static partial class ContentEvent
    {
        /// <summary>
        /// <para>Fired after a copy object has been created and had its parentId updated and its state has been set to unpublished.</para>
        /// <para>Signature: <bold>foo(IContentService sender, Umbraco.Core.Events.CopyEventArgs&lt;IContent&gt; e)</bold></para>
        /// </summary>
        /// <remarks></remarks>
        /// <code>MethodName(IContentService sender, Umbraco.Core.Events.CopyEventArgs&lt;IContent&gt; e)</code>
        [AttributeUsage(AttributeTargets.Method)]
        public class Copying : Attribute, IBindToEvent
        {
            /// <summary>
            /// Content Type Alias to filter (if specified)
            /// </summary>
            public string[] ContentTypeAliases { get; set; }

            /// <summary>
            /// Methods to bind - used in the event filter
            /// </summary>
            protected MethodInfo MethodToBind { get; set; }

            
            public Copying() { ContentTypeAliases = new string[] {}; }

            /// <summary>
            /// Filter by Content Type Aliases
            /// </summary>
            /// <param name="contentTypeAlias"></param>
            public Copying(params string[] contentTypeAliases)
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
                    ContentService.Copying += FilterEvent;
                }
                else
                {
                    //bind without filter
                    var eventBinder = new EventBinder();
                    eventBinder.BindToEvent(typeof(ContentService), "Copying", methodToBind);
                }
            }

            void FilterEvent(IContentService sender, Umbraco.Core.Events.CopyEventArgs<IContent> e)
            {
                //check if this is a valid content type
                if (ContentTypeAliases.Contains(e.Original.ContentType.Alias))
                {
                    MethodToBind.Invoke(null, new object[] { sender, e });
                }
            }
        }
    }
}