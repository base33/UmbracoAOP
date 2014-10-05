using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UmbracoAOP.EventSubscriber.Attributes
{
    interface IBindToEvent
    {
        void Bind(MethodInfo methodToBind);
    }
}
