using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace UmbracoAOP.EventSubscriber.Binders.ContentEvents
{
    public class EventValidatorMappings
    {
        /// <summary>
        /// a list of key value pairs where:
        /// - key = a function that takes a methodinfo and returns whether the method is valid for the event
        /// - value = a function that accepts MethodInfo and UmbracoEventAttribute
        /// </summary>

        public static List<KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>> Mappings = new List<KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>>
                {
                    ///Special Cases
                    //sent to publish
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.SentToPublish, (mi, att) => { new ContentEventBinder().SentToPublish(mi, att); }),
                    //sending to publish
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.SendingToPublish, (mi, att) => { new ContentEventBinder().SendingToPublish(mi, att); }),
                    //unpublished
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.Unpublished, (mi, att) => { new ContentEventBinder().Unpublished(mi, att); }),
                    //unpublished
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.Unpublishing, (mi, att) => { new ContentEventBinder().Unpublishing(mi, att); }),

                    //copied
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.Copied, (mi, att) => { new ContentEventBinder().Copied(mi, att); }),
                    //coping
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.Copying, (mi, att) => { new ContentEventBinder().Copying(mi, att); }),
                    //created
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.Created, (mi, att) => { new ContentEventBinder().Created(mi, att); }),
                    //deleted
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.Deleted, (mi, att) => { new ContentEventBinder().Deleted(mi, att); }),
                    //deleting
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.Deleting, (mi, att) => { new ContentEventBinder().Deleting(mi, att); }),
                    //emptied recycle bin
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.EmptiedRecycleBin, (mi, att) => { new ContentEventBinder().EmptiedRecycleBin(mi, att); }),
                    //emptying recycle bin
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.EmptyingRecycleBin, (mi, att) => { new ContentEventBinder().EmptyingRecycleBin(mi, att); }),
                    //moved
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.Moved, (mi, att) => { new ContentEventBinder().Moved(mi, att); }),
                    //moving
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.Moving, (mi, att) => { new ContentEventBinder().Moving(mi, att); }),
                    //published
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.Published, (mi, att) => { new ContentEventBinder().Published(mi, att); }),
                    //publishing
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.Publishing, (mi, att) => { new ContentEventBinder().Publishing(mi, att); }),
                    //rolled back
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.RolledBack, (mi, att) => { new ContentEventBinder().RolledBack(mi, att); }),
                    //rolling back
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.RollingBack, (mi, att) => { new ContentEventBinder().RollingBack(mi, att); }),
                    //save
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.Saved, (mi, att) => { new ContentEventBinder().Saved(mi, att); }),
                    //saving
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.Saving, (mi, att) => { new ContentEventBinder().Saving(mi, att); }),
                    //trashed
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.Trashed, (mi, att) => { new ContentEventBinder().Trashed(mi, att); }),
                    //trashing
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.Trashing, (mi, att) => { new ContentEventBinder().Trashing(mi, att); }),
                    
                };
    }
}