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

        //[ContentEvent.Published("umbTextPage")]
        //public static void Published(IPublishingStrategy sender, PublishEventArgs<IContent> e)
        //{
        //    int i = 0;
        //}

        //[ContentEvent.Publishing("umbTextPage", "umbHomePage")]
        //public static void Publishing(IPublishingStrategy sender, PublishEventArgs<IContent> e)
        //{
        //    int i = 0;
        //}

        //[ContentEvent.Copied]
        //public static void Copied(IContentService sender, CopyEventArgs<IContent> e)
        //{
        //    int i = 0;
        //}

        //[ContentEvent.Copying]
        //public static void Copying(IContentService sender, CopyEventArgs<IContent> e)
        //{
        //    int i = 0;
        //}

        //[ContentEvent.Deleted]
        //public static void Deleted(IContentService sender, DeleteEventArgs<IContent> e)
        //{
        //    int i = 0;
        //}

        //[ContentEvent.Deleting]
        //public static void Deleting(IContentService sender, DeleteEventArgs<IContent> e)
        //{
        //    int i = 0;
        //}

        //[ContentEvent.Moved]
        //public static void Moved(IContentService sender, MoveEventArgs<IContent> e)
        //{
        //    int i = 0;
        //}

        //[ContentEvent.Moving]
        //public static void Moving(IContentService sender, MoveEventArgs<IContent> e)
        //{
        //    int i = 0;
        //}
    }
}