using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Umbraco.Core.Publishing;
using Umbraco.Core.Services;
using UmbracoAOP.EventSubscriber.Binders;
using UmbracoAOP.EventSubscriber.Binders.ContentEvents;

namespace UmbracoAOP.EventSubscriber.Binders
{
    class EventBindingsLookup
    {

        public Action<MethodInfo, UmbracoEventAttribute> LookUpValidEventBinder(MethodInfo methodInfo)
        {
            ParameterInfo[] parameters = methodInfo.GetParameters();

            if (parameters.Count() == 2)
            {

                //resolve whether this is a content event, media or other
                if (parameters[0].ParameterType == typeof(IContentService) || 
                    parameters[0].ParameterType == typeof(IPublishingStrategy))
                    return lookUpValidEventBinderList(ContentEvents.EventValidatorMappings.Mappings, methodInfo, parameters);
                else if (parameters[0].ParameterType == typeof(IMediaService))
                    return null;
                else if (parameters[0].ParameterType == typeof(IContentTypeService))
                    return null;
                
            }

            return null;
        }

        /// <summary>
        /// Runs through the list running all validators until one is found or at the end
        /// if valid, will return the function that will bind the methodInfo to the event
        /// </summary>
        /// <param name="eventValidatorMappings">The list of event validator mappings</param>
        /// <param name="methodInfo">The method info to validate</param>
        /// <param name="parameters">The parameters for the MethodInfo.  Do methodInfo.GetParameters()</param>
        /// <returns>An Action&lt;MethodInfo&gt; that will bind the method to the event</returns>
        protected Action<MethodInfo, UmbracoEventAttribute> lookUpValidEventBinderList(
            List<KeyValuePair<Func<MethodInfo, bool>, Action<MethodInfo, UmbracoEventAttribute>>> eventValidatorMappings, 
            MethodInfo methodInfo, ParameterInfo[] parameters)
        {
            Type senderType = parameters.ElementAt(0).ParameterType;
            Type eventArgsType = parameters.ElementAt(1).ParameterType;

            foreach (var eventValidatorMapping in eventValidatorMappings)
            {
                //run the validate function
                if (eventValidatorMapping.Key(methodInfo))
                    //return the bind function
                    return eventValidatorMapping.Value;
            }

            return null;
        }
    }
}
