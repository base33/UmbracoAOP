using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Umbraco.Core.Services;

namespace UmbracoAOP.EventSubscriber
{
    public class ReflectionHelper
    {
        /// <summary>
        /// Gets all methods marked with an attribute.  This only maps an attribute to methods.
        /// <remarks>This is method should not be used when an attribute contains values.</remarks>
        /// </summary>
        /// <param name="attributeTypes"></param>
        /// <returns></returns>
        public static AttributeToMethodList GetMethodsWithAttribute(params Type[] attributeTypes)
        {
            var results = new AttributeToMethodList();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToArray();
            
            foreach (var assembly in assemblies)
            {
                try
                {
                    foreach(var method in from type in assembly.GetTypes()
                                            from method in type.GetMethods()
                                            select method)
                    {
                        foreach (var attributeType in attributeTypes)
                        {
                            if (Attribute.IsDefined(method, attributeType))
                            {
                                var attrInstance = method.GetCustomAttribute(attributeType, false);
                                results.Add(attrInstance, method);
                            }
                        }
                    }
                }
                catch(Exception)
                {

                }
            }

            return results;
        }

        
    }
}