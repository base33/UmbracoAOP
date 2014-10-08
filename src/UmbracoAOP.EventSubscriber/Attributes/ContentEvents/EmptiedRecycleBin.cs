using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using umbraco.BusinessLogic;
using umbraco.cms.businesslogic.web;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace UmbracoAOP.EventSubscriber.Attributes.ContentEvents
{
    public static partial class ContentEvent
    {
        /// <summary>
        /// <para>Fired after the content object has been moved.</para>
        /// <para>Signature: <bold>foo(IContentService sender, Umbraco.Core.Events.MoveEventArgs&lt;IContent&gt; e)</bold></para>
        /// </summary>
        /// <remarks></remarks>
        /// <code>MethodName(IContentService sender, Umbraco.Core.Events.MoveEventArgs&lt;IContent&gt; e)</code>
        [AttributeUsage(AttributeTargets.Method)]
        public class EmptiedRecycleBin : Attribute, IBindToEvent
        {
            /// <summary>
            /// Binds the method to the event
            /// </summary>
            /// <param name="methodToBind"></param>
            public void Bind(MethodInfo methodToBind)
            {
                //bind without filter
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(ContentService), "EmptiedRecycleBin", methodToBind);
            }
        }
    }
}