using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UmbracoAOP.EventSubscriber.Binders
{
    public interface IEventBinder
    {
        void Bind(string[] contentTypeAliases, MethodInfo[] methodToBind);
        IEventBinder CreateNew();
    }
}
