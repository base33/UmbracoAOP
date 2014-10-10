using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Publishing;
using Umbraco.Core.Services;

namespace UmbracoAOP.EventSubscriber.Binders.ContentEvents
{
    public class EventValidators
    {
        

        protected static bool Validate(MethodInfo methodInfo, string expectedSuffix, Type expectedSender, Type expectedEventArgs)
        {
            ParameterInfo[] parameters = methodInfo.GetParameters();
            return methodInfo.Name.EndsWith(expectedSuffix, StringComparison.OrdinalIgnoreCase) &&
                   expectedSender == parameters[0].ParameterType &&

                   expectedEventArgs == parameters[1].ParameterType;
        }

        internal static bool Copied(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "Copied", typeof(IContentService), typeof(CopyEventArgs<IContent>));
        }

        internal static bool Copying(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "Copying", typeof(IContentService), typeof(CopyEventArgs<IContent>));
        }

        internal static bool Created(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "Created", typeof(IContentService), typeof(NewEventArgs<IContent>));
        }

        internal static bool Creating(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "Creating", typeof(IContentService), typeof(NewEventArgs<IContent>));
        }

        internal static bool Deleted(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "Deleted", typeof(IContentService), typeof(DeleteEventArgs<IContent>));
        }

        internal static bool Deleting(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "Deleting", typeof(IContentService), typeof(DeleteEventArgs<IContent>));
        }

        internal static bool EmptiedRecycleBin(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "EmptiedRecycleBin", typeof(IContentService), typeof(RecycleBinEventArgs));
        }

        internal static bool EmptyingRecycleBin(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "EmptyingRecycleBin", typeof(IContentService), typeof(RecycleBinEventArgs));
        }

        internal static bool Moved(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "Moved", typeof(IContentService), typeof(MoveEventArgs<IContent>));
        }

        internal static bool Moving(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "Moving", typeof(IContentService), typeof(MoveEventArgs<IContent>));
        }

        internal static bool Published(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "Published", typeof(IPublishingStrategy), typeof(PublishEventArgs<IContent>));
        }

        internal static bool Publishing(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "Publishing", typeof(IPublishingStrategy), typeof(PublishEventArgs<IContent>));

        }

        internal static bool RolledBack(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "RolledBack", typeof(IContentService), typeof(RollbackEventArgs<IContent>));
        }

        internal static bool RollingBack(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "RollingBack", typeof(IContentService), typeof(RollbackEventArgs<IContent>));
        }

        internal static bool Saved(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "Saved", typeof(IContentService), typeof(SaveEventArgs<IContent>));

        }

        internal static bool Saving(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "Saving", typeof(IContentService), typeof(SaveEventArgs<IContent>));
        }

        internal static bool SentToPublish(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "SentToPublish", typeof(IContentService), typeof(SendToPublishEventArgs<IContent>));
        }

        internal static bool SendingToPublish(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "SendingToPublish", typeof(IContentService), typeof(SendToPublishEventArgs<IContent>));
        }

        internal static bool Trashed(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "Trashed", typeof(IContentService), typeof(MoveEventArgs<IContent>));
        }

        internal static bool Trashing(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "Trashing", typeof(IContentService), typeof(MoveEventArgs<IContent>));
        }

        internal static bool Unpublished(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "Unpublished", typeof(IPublishingStrategy), typeof(PublishEventArgs<IContent>));
        }

        internal static bool Unpublishing(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "Unpublishing", typeof(IPublishingStrategy), typeof(PublishEventArgs<IContent>));
        }
    }
}