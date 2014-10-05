using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace UmbracoAOP.EventSubscriber
{
    public class EventBinder
    {
        public void BindToEvent(Type hostType, string eventName, MethodInfo methodToBind)
        {
            // Create an EventInfo object representing the event and use the 
            // EventHandlerType property to determine the type of delegate
            // that will handle the event. 
            EventInfo eventInfo = hostType.GetEvent(eventName);
            Type handlerDelegate = eventInfo.EventHandlerType;

            try
            {
                //bind to the event
                Delegate d = Delegate.CreateDelegate(handlerDelegate, methodToBind);
                eventInfo.AddEventHandler(hostType, d);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void BindToInstanceEvent(Type hostType, string eventName, MethodInfo[] methodsToBind, object instance)
        {
            // Create an EventInfo object representing the event and use the 
            // EventHandlerType property to determine the type of delegate
            // that will handle the event. 
            EventInfo eventInfo = hostType.GetEvent(eventName);
            Type handlerDelegate = eventInfo.EventHandlerType;

            foreach (var methodToBind in methodsToBind)
            {
                try
                {
                    //bind to the event
                    Delegate d = Delegate.CreateDelegate(handlerDelegate, instance, methodToBind);
                    eventInfo.AddEventHandler(hostType, d);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}