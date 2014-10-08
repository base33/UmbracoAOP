using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UmbracoAOP.EventSubscriber.Binders;
using UmbracoAOP.EventSubscriber.Binders.ContentEvents;

namespace UmbracoAOP.EventSubscriber.Binders
{
    class EventBindingsLookup
    {
        protected ContentEventBase[] ContentEventBindings = new ContentEventBase[]
                {
                    new ContentEvent.Copied(),
                    new ContentEvent.Copying(),
                    //typeof (ContentEvent.Deleted),
                    //typeof (ContentEvent.Deleting),
                    //typeof (ContentEvent.EmptiedRecycleBin),
                    //typeof (ContentEvent.EmptyingRecycleBin),
                    //typeof (ContentEvent.Moved),
                    //typeof (ContentEvent.Moving),
                    //typeof (ContentEvent.Published),
                    //typeof (ContentEvent.Publishing),
                    //typeof (ContentEvent.RolledBack),
                    //typeof (ContentEvent.RollingBack),
                    new ContentEvent.Saved(),
                    new ContentEvent.Saving()
                    //typeof (ContentEvent.SendingToPublish),
                    //typeof (ContentEvent.SentToPublish),
                    //typeof (ContentEvent.Trashed),
                    //typeof (ContentEvent.Trashing)
                };

        public IEventBinder LookUpValidEventBinder(MethodInfo methodInfo)
        {
            string methodSuffix = methodInfo.Name.Split('_').Last();
            ParameterInfo[] parameters = methodInfo.GetParameters();

            if (parameters.Count() == 2)
            {

                Type senderType = parameters.ElementAt(0).ParameterType;
                Type eventArgsType = parameters.ElementAt(1).ParameterType;

                foreach (IEventValidator contentEvent in ContentEventBindings)
                {
                    if (contentEvent.Validate(methodSuffix, senderType, eventArgsType))
                        return ((IEventBinder)contentEvent).CreateNew();
                }
            }

            return null;
        }
    }
}
