using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Umbraco.Core.Services;

namespace UmbracoAOP.EventSubscriber.Binders.MediaEvents
{
    public class MediaEventBinder
    {
        public string[] ContentTypeAliases { get; set; }
        public MethodInfo MethodToBind { get; set; }

        public MediaEventBinder()
        {
        }

        #region Deleted
        public void Deleted(MethodInfo methodInfo, UmbracoEventAttribute attribute)
        {
            if (attribute.ContentTypeAliases.Any())
            {
                ContentTypeAliases = attribute.ContentTypeAliases;
                MethodToBind = methodInfo;
                MediaService.Deleted += Filtered_Deleted;
            }
            else
            {
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(MediaService), "Deleted", methodInfo);
            }
        }

        void Filtered_Deleted(IMediaService sender, Umbraco.Core.Events.DeleteEventArgs<Umbraco.Core.Models.IMedia> e)
        {
            if (e.DeletedEntities.Select(d => d.ContentType.Alias).Intersect(ContentTypeAliases).Any())
                MethodToBind.Invoke(null, new object[] { sender, e });
        }
        #endregion

        #region Deleting
        public void Deleting(MethodInfo methodInfo, UmbracoEventAttribute attribute)
        {
            if (attribute.ContentTypeAliases.Any())
            {
                ContentTypeAliases = attribute.ContentTypeAliases;
                MethodToBind = methodInfo;
                MediaService.Deleting += Filtered_Deleting;
            }
            else
            {
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(MediaService), "Deleting", methodInfo);
            }
        }

        void Filtered_Deleting(IMediaService sender, Umbraco.Core.Events.DeleteEventArgs<Umbraco.Core.Models.IMedia> e)
        {
            if (e.DeletedEntities.Select(d => d.ContentType.Alias).Intersect(ContentTypeAliases).Any())
                MethodToBind.Invoke(null, new object[] { sender, e });
        }
        #endregion

        #region Moved
        public void Moved(MethodInfo methodInfo, UmbracoEventAttribute attribute)
        {
            if (attribute.ContentTypeAliases.Any())
            {
                ContentTypeAliases = attribute.ContentTypeAliases;
                MethodToBind = methodInfo;
                MediaService.Moved += Filtered_Moved;
            }
            else
            {
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(MediaService), "Moved", methodInfo);
            }
        }

        void Filtered_Moved(IMediaService sender, Umbraco.Core.Events.MoveEventArgs<Umbraco.Core.Models.IMedia> e)
        {
            if (e.MoveInfoCollection.Select(c => c.Entity.ContentType.Alias).Intersect(ContentTypeAliases).Any())
                MethodToBind.Invoke(null, new object[] { sender, e });
        }
        #endregion

        #region Moving
        public void Moving(MethodInfo methodInfo, UmbracoEventAttribute attribute)
        {
            if (attribute.ContentTypeAliases.Any())
            {
                ContentTypeAliases = attribute.ContentTypeAliases;
                MethodToBind = methodInfo;
                MediaService.Moving += Filtered_Moving;
            }
            else
            {
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(MediaService), "Moving", methodInfo);
            }
        }

        void Filtered_Moving(IMediaService sender, Umbraco.Core.Events.MoveEventArgs<Umbraco.Core.Models.IMedia> e)
        {
            if (e.MoveInfoCollection.Select(c => c.Entity.ContentType.Alias).Intersect(ContentTypeAliases).Any())
                MethodToBind.Invoke(null, new object[] { sender, e });
        }
        #endregion

        #region Saved
        public void Saved(MethodInfo methodInfo, UmbracoEventAttribute attribute)
        {
            if (attribute.ContentTypeAliases.Any())
            {
                ContentTypeAliases = attribute.ContentTypeAliases;
                MethodToBind = methodInfo;
                MediaService.Saved += Filtered_Saved;
            }
            else
            {
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(MediaService), "Saved", methodInfo);
            }
        }

        void Filtered_Saved(IMediaService sender, Umbraco.Core.Events.SaveEventArgs<Umbraco.Core.Models.IMedia> e)
        {
            if (e.SavedEntities.Select(c => c.ContentType.Alias).Intersect(ContentTypeAliases).Any())
                MethodToBind.Invoke(null, new object[] { sender, e });
        }
        #endregion

        #region Saving
        public void Saving(MethodInfo methodInfo, UmbracoEventAttribute attribute)
        {
            if (attribute.ContentTypeAliases.Any())
            {
                ContentTypeAliases = attribute.ContentTypeAliases;
                MethodToBind = methodInfo;
                MediaService.Saving += Filtered_Saving;
            }
            else
            {
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(MediaService), "Saved", methodInfo);
            }
        }

        void Filtered_Saving(IMediaService sender, Umbraco.Core.Events.SaveEventArgs<Umbraco.Core.Models.IMedia> e)
        {
            if (e.SavedEntities.Select(c => c.ContentType.Alias).Intersect(ContentTypeAliases).Any())
                MethodToBind.Invoke(null, new object[] { sender, e });
        }
        #endregion

        #region Trashed
        public void Trashed(MethodInfo methodInfo, UmbracoEventAttribute attribute)
        {
            if (attribute.ContentTypeAliases.Any())
            {
                ContentTypeAliases = attribute.ContentTypeAliases;
                MethodToBind = methodInfo;
                MediaService.Trashed += Filtered_Trashed;
            }
            else
            {
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(MediaService), "Trashed", methodInfo);
            }
        }

        void Filtered_Trashed(IMediaService sender, Umbraco.Core.Events.MoveEventArgs<Umbraco.Core.Models.IMedia> e)
        {
            if (e.MoveInfoCollection.Select(c => c.Entity.ContentType.Alias).Intersect(ContentTypeAliases).Any())
                MethodToBind.Invoke(null, new object[] { sender, e });
        }
        #endregion

        #region Trashing
        public void Trashing(MethodInfo methodInfo, UmbracoEventAttribute attribute)
        {
            if (attribute.ContentTypeAliases.Any())
            {
                ContentTypeAliases = attribute.ContentTypeAliases;
                MethodToBind = methodInfo;
                MediaService.Trashing += Filtered_Trashing;
            }
            else
            {
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(MediaService), "Trashing", methodInfo);
            }
        }

        void Filtered_Trashing(IMediaService sender, Umbraco.Core.Events.MoveEventArgs<Umbraco.Core.Models.IMedia> e)
        {
            if (e.MoveInfoCollection.Select(c => c.Entity.ContentType.Alias).Intersect(ContentTypeAliases).Any())
                MethodToBind.Invoke(null, new object[] { sender, e });
        }
        #endregion
    }
}