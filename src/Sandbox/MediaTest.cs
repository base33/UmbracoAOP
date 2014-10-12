using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using UmbracoAOP.EventSubscriber;

namespace Sandbox
{
    public class MediaTest
    {
        [UmbracoEvent]
        public static void DoSomethingWhenSaved(IMediaService sender, SaveEventArgs<IMedia> e)
        {
            int i = 0;
        }

        [UmbracoEvent]
        public static void DoSomethingWhenSaving(IMediaService sender, SaveEventArgs<IMedia> e)
        {
            int i = 0;
        }

        [UmbracoEvent("File")]
        public static void DoSomethingForFilesWhenSaved(IMediaService sender, SaveEventArgs<IMedia> e)
        {
            int i = 0;
        }

        [UmbracoEvent]
        public static void DoSomethingForFoldersWhenSaving(IMediaService sender, SaveEventArgs<IMedia> e)
        {
            int i = 0;
        }

        [UmbracoEvent]
        public static void DoSomethingWhenTrashing(IMediaService sender, MoveEventArgs<IMedia> e)
        {
            int i = 0;
        }

        [UmbracoEvent]
        public static void DoSomethingWhenTrashed(IMediaService sender, MoveEventArgs<IMedia> e)
        {
            int i = 0;
        }

        [UmbracoEvent]
        public static void DoSomethingWhenDeleting(IMediaService sender, DeleteEventArgs<IMedia> e)
        {
            int i = 0;
        }

        [UmbracoEvent]
        public static void DoSomethingWhenDeleted(IMediaService sender, DeleteEventArgs<IMedia> e)
        {
            int i = 0;
        }

        [UmbracoEvent]
        public static void DoSomethingWhenMoved(IMediaService sender, MoveEventArgs<IMedia> e)
        {
            int i = 0;
        }

        [UmbracoEvent]
        public static void DoSomethingWhenMoving(IMediaService sender, MoveEventArgs<IMedia> e)
        {
            int i = 0;
        }
    }
}