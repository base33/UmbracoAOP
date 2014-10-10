using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco.cms.businesslogic;
using umbraco.cms.businesslogic.web;
using Umbraco.Core.Services;
using Umbraco.Core.Models;
using Umbraco.Core.Publishing;
using Umbraco.Core.Events;
using UmbracoAOP.EventSubscriber;

namespace Sandbox
{
    public class ContentTest
    {
        [UmbracoEvent]
        public static void Content_Saved(IContentService sender, Umbraco.Core.Events.SaveEventArgs<Umbraco.Core.Models.IContent> e)
        {
            int i = 0;


        }

        [UmbracoEvent("umbHomePage")]
        public static void HomePage_Saving(IContentService sender, Umbraco.Core.Events.SaveEventArgs<IContent> e)
        {
            int i = 0;

        }

        [UmbracoEvent("umbTextPage")]
        public static void TextPage_Published(IPublishingStrategy sender, PublishEventArgs<IContent> e)
        {
            int i = 0;
        }

        [UmbracoEvent("umbTextPage", "umbHomePage")]
        public static void TextAndHome_OnPublishing(IPublishingStrategy sender, PublishEventArgs<IContent> e)
        {
            int i = 0;
        }

        [UmbracoEvent]
        public static void DoSomethingWhenCopied(IContentService sender, CopyEventArgs<IContent> e)
        {
            int i = 0;
        }

        [UmbracoEvent]
        public static void DoSomethingOnCopying(IContentService sender, CopyEventArgs<IContent> e)
        {
            int i = 0;
        }

        [UmbracoEvent]
        public static void DoOnDeleted(IContentService sender, DeleteEventArgs<IContent> e)
        {
            int i = 0;
        }

        [UmbracoEvent("umbTextPage")]
        public static void DoOnDeleting(IContentService sender, DeleteEventArgs<IContent> e)
        {
            int i = 0;
        }

        [UmbracoEvent]
        public static void DoOn_Moved(IContentService sender, MoveEventArgs<IContent> e)
        {
            int i = 0;
        }

        [UmbracoEvent]
        public static void Moving(IContentService sender, MoveEventArgs<IContent> e)
        {
            int i = 0;
        }

        [UmbracoEvent]
        public static void WhenTrashed(IContentService sender, MoveEventArgs<IContent> e)
        {
            int i = 0;
        }

        [UmbracoEvent]
        public static void WhenTrashing(IContentService sender, MoveEventArgs<IContent> e)
        {
            int i = 0;
        }

        [UmbracoEvent("umbHomePage")]
        public static void WhenUnpublished(IPublishingStrategy sender, PublishEventArgs<IContent> e)
        {
            int i = 0;
        }

        [UmbracoEvent]
        public static void WhenUnpublishing(IPublishingStrategy sender, PublishEventArgs<IContent> e)
        {
            int i = 0;
        }

        [UmbracoEvent]
        public static void WhenCreated(IContentService sender, NewEventArgs<IContent> e)
        {
            int i = 0;
        }
    }
}