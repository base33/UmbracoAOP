using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace UmbracoAOP.EventSubscriber.Binders.MediaEvents
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
                    //deleted
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.Deleted, (mi, att) => { new MediaEventBinder().Deleted(mi, att); }),
                    //deleting
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.Deleting, (mi, att) => { new MediaEventBinder().Deleting(mi, att); }),
                    //moved
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.Moved, (mi, att) => { new MediaEventBinder().Moved(mi, att); }),
                    //moving
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.Moving, (mi, att) => { new MediaEventBinder().Moving(mi, att); }),
                    //save
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.Saved, (mi, att) => { new MediaEventBinder().Saved(mi, att); }),
                    //saving
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.Saving, (mi, att) => { new MediaEventBinder().Saving(mi, att); }),
                    //trashed
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.Trashed, (mi, att) => { new MediaEventBinder().Trashed(mi, att); }),
                    //trashing
                    new KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>(EventValidators.Trashing, (mi, att) => { new MediaEventBinder().Trashing(mi, att); }),
                    
                };
    }
}