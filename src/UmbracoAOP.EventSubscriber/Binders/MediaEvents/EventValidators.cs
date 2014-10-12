using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Publishing;
using Umbraco.Core.Services;

namespace UmbracoAOP.EventSubscriber.Binders.MediaEvents
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

        internal static bool Deleted(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "Deleted", typeof(IMediaService), typeof(DeleteEventArgs<IMedia>));
        }

        internal static bool Deleting(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "Deleting", typeof(IMediaService), typeof(DeleteEventArgs<IMedia>));
        }

        internal static bool Moved(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "Moved", typeof(IMediaService), typeof(MoveEventArgs<IMedia>));
        }

        internal static bool Moving(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "Moving", typeof(IMediaService), typeof(MoveEventArgs<IMedia>));
        }

        internal static bool Saved(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "Saved", typeof(IMediaService), typeof(SaveEventArgs<IMedia>));
        }

        internal static bool Saving(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "Saving", typeof(IMediaService), typeof(SaveEventArgs<IMedia>));
        }

        internal static bool Trashed(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "Trashed", typeof(IMediaService), typeof(MoveEventArgs<IMedia>));
        }

        internal static bool Trashing(MethodInfo methodInfo)
        {
            return Validate(methodInfo, "Trashing", typeof(IMediaService), typeof(MoveEventArgs<IMedia>));
        }
    }
}