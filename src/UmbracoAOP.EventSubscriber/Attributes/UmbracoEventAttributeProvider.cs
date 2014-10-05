using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UmbracoAOP.EventSubscriber.Attributes.ContentEvents;

namespace UmbracoAOP.EventSubscriber
{
    class UmbracoEventAttributeProvider
    {
        public Type[] Get()
        {
            var attributes = new List<Type>();

            //load in content events
            attributes.AddRange(GetContentEventAttributes());


            return attributes.ToArray();
        }

        protected Type[] GetContentEventAttributes()
        {
            return new[]
                {
                    typeof (ContentEvent.Copied),
                    typeof (ContentEvent.Copying),
                    typeof (ContentEvent.Deleted),
                    typeof (ContentEvent.Deleting),
                    typeof (ContentEvent.EmptiedRecycleBin),
                    typeof (ContentEvent.EmptyingRecycleBin),
                    typeof (ContentEvent.Moved),
                    typeof (ContentEvent.Moving),
                    typeof (ContentEvent.Published),
                    typeof (ContentEvent.Publishing),
                    typeof (ContentEvent.RolledBack),
                    typeof (ContentEvent.RollingBack),
                    typeof (ContentEvent.Saved),
                    typeof (ContentEvent.Saving),
                    typeof (ContentEvent.SendingToPublish),
                    typeof (ContentEvent.SentToPublish),
                    typeof (ContentEvent.Trashed),
                    typeof (ContentEvent.Trashing)
                };
        }
    }
}
