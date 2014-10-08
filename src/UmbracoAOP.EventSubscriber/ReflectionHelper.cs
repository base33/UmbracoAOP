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
        public static List<AttributeToMethod> GetMethodsWithAttribute(Type attributeType)
        {
            var results = new List<AttributeToMethod>();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToArray();
            
            foreach (var assembly in assemblies)
            {
                try
                {
                    foreach(var method in from type in assembly.GetTypes()
                                            from method in type.GetMethods()
                                            select method)
                    {
                        if (Attribute.IsDefined(method, attributeType))
                        {
                            var attrInstance = method.GetCustomAttribute(attributeType, false);
                            results.Add(new AttributeToMethod(attrInstance, method));
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