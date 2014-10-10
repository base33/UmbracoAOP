using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Umbraco.Core.Services;

namespace UmbracoAOP.EventSubscriber.Binders.ContentEvents
{
    public class ContentEventBinder
    {
        public string[] ContentTypeAliases { get; set; }
        public MethodInfo MethodToBind { get; set; }

        public ContentEventBinder()
        {
        }

        #region Copied
        public void Copied(MethodInfo methodInfo, UmbracoEventAttribute attribute)
        {
            if (attribute.ContentTypeAliases.Any())
            {
                ContentTypeAliases = attribute.ContentTypeAliases;
                MethodToBind = methodInfo;
                ContentService.Copied += Filtered_Copied;
            }
            else
            {
                EventBinder eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(ContentService), "Copied", methodInfo);
            }
        }

        void Filtered_Copied(IContentService sender, Umbraco.Core.Events.CopyEventArgs<Umbraco.Core.Models.IContent> e)
        {
            if (ContentTypeAliases.Contains(e.Original.ContentType.Alias))
                MethodToBind.Invoke(null, new object[] { sender, e });
        }
        #endregion

        #region Copying
        public void Copying(MethodInfo methodInfo, UmbracoEventAttribute attribute)
        {
            if (attribute.ContentTypeAliases.Any())
            {
                ContentTypeAliases = attribute.ContentTypeAliases;
                MethodToBind = methodInfo;
                ContentService.Copying += Filtered_Copying;
            }
            else
            {
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(ContentService), "Copying", methodInfo);
            }
        }

        void Filtered_Copying(IContentService sender, Umbraco.Core.Events.CopyEventArgs<Umbraco.Core.Models.IContent> e)
        {
            if (ContentTypeAliases.Contains(e.Original.ContentType.Alias))
                MethodToBind.Invoke(null, new object[] { sender, e });
        }
        #endregion

        #region Created
        public void Created(MethodInfo methodInfo, UmbracoEventAttribute attribute)
        {
            if (attribute.ContentTypeAliases.Any())
            {
                ContentTypeAliases = attribute.ContentTypeAliases;
                MethodToBind = methodInfo;
                ContentService.Created += Filtered_Created;
            }
            else
            {
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(ContentService), "Created", methodInfo);
            }
        }

        void Filtered_Created(IContentService sender, Umbraco.Core.Events.NewEventArgs<Umbraco.Core.Models.IContent> e)
        {
            if (ContentTypeAliases.Contains(e.Entity.ContentType.Alias))
                MethodToBind.Invoke(null, new object[] { sender, e });
        }
        #endregion

        #region Deleted
        public void Deleted(MethodInfo methodInfo, UmbracoEventAttribute attribute)
        {
            if (attribute.ContentTypeAliases.Any())
            {
                ContentTypeAliases = attribute.ContentTypeAliases;
                MethodToBind = methodInfo;
                ContentService.Deleted += Filtered_Deleted;
            }
            else
            {
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(ContentService), "Deleted", methodInfo);
            }
        }

        void Filtered_Deleted(IContentService sender, Umbraco.Core.Events.DeleteEventArgs<Umbraco.Core.Models.IContent> e)
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
                ContentService.Deleting += Filtered_Deleting;
            }
            else
            {
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(ContentService), "Deleting", methodInfo);
            }
        }

        void Filtered_Deleting(IContentService sender, Umbraco.Core.Events.DeleteEventArgs<Umbraco.Core.Models.IContent> e)
        {
            if (e.DeletedEntities.Select(d => d.ContentType.Alias).Intersect(ContentTypeAliases).Any())
                MethodToBind.Invoke(null, new object[] { sender, e });
        }
        #endregion

        #region EmptiedRecyleBin
        public void EmptiedRecycleBin(MethodInfo methodInfo, UmbracoEventAttribute attribute)
        {
            var eventBinder = new EventBinder();
            eventBinder.BindToEvent(typeof(ContentService), "EmptiedRecycleBin", methodInfo);
        }
        #endregion

        #region EmptyingRecycleBin
        public void EmptyingRecycleBin(MethodInfo methodInfo, UmbracoEventAttribute attribute)
        {
            var eventBinder = new EventBinder();
            eventBinder.BindToEvent(typeof(ContentService), "EmptyingRecycleBin", methodInfo);
        }
        #endregion

        #region Moved
        public void Moved(MethodInfo methodInfo, UmbracoEventAttribute attribute)
        {
            if (attribute.ContentTypeAliases.Any())
            {
                ContentTypeAliases = attribute.ContentTypeAliases;
                MethodToBind = methodInfo;
                ContentService.Moved += Filtered_Moved;
            }
            else
            {
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(ContentService), "Moved", methodInfo);
            }
        }

        void Filtered_Moved(IContentService sender, Umbraco.Core.Events.MoveEventArgs<Umbraco.Core.Models.IContent> e)
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
                ContentService.Moving += Filtered_Moving;
            }
            else
            {
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(ContentService), "Moving", methodInfo);
            }
        }

        void Filtered_Moving(IContentService sender, Umbraco.Core.Events.MoveEventArgs<Umbraco.Core.Models.IContent> e)
        {
            if (e.MoveInfoCollection.Select(c => c.Entity.ContentType.Alias).Intersect(ContentTypeAliases).Any())
                MethodToBind.Invoke(null, new object[] { sender, e });
        }
        #endregion

        #region Published
        public void Published(MethodInfo methodInfo, UmbracoEventAttribute attribute)
        {
            if (attribute.ContentTypeAliases.Any())
            {
                ContentTypeAliases = attribute.ContentTypeAliases;
                MethodToBind = methodInfo;
                ContentService.Published += Filtered_Published;
            }
            else
            {
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(ContentService), "Published", methodInfo);
            }
        }

        void Filtered_Published(Umbraco.Core.Publishing.IPublishingStrategy sender, Umbraco.Core.Events.PublishEventArgs<Umbraco.Core.Models.IContent> e)
        {
            if (e.PublishedEntities.Select(c => c.ContentType.Alias).Intersect(ContentTypeAliases).Any())
                MethodToBind.Invoke(null, new object[] { sender, e });
        }
        #endregion

        #region Publishing
        public void Publishing(MethodInfo methodInfo, UmbracoEventAttribute attribute)
        {
            if (attribute.ContentTypeAliases.Any())
            {
                ContentTypeAliases = attribute.ContentTypeAliases;
                MethodToBind = methodInfo;
                ContentService.Publishing += Filtered_Publishing;
            }
            else
            {
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(ContentService), "Publishing", methodInfo);
            }
        }

        void Filtered_Publishing(Umbraco.Core.Publishing.IPublishingStrategy sender, Umbraco.Core.Events.PublishEventArgs<Umbraco.Core.Models.IContent> e)
        {
            if (e.PublishedEntities.Select(c => c.ContentType.Alias).Intersect(ContentTypeAliases).Any())
                MethodToBind.Invoke(null, new object[] { sender, e });
        }
        #endregion

        #region RolledBack
        public void RolledBack(MethodInfo methodInfo, UmbracoEventAttribute attribute)
        {
            if (attribute.ContentTypeAliases.Any())
            {
                ContentTypeAliases = attribute.ContentTypeAliases;
                MethodToBind = methodInfo;
                ContentService.RolledBack += Filtered_RolledBack;
            }
            else
            {
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(ContentService), "RolledBack", methodInfo);
            }
        }

        void Filtered_RolledBack(IContentService sender, Umbraco.Core.Events.RollbackEventArgs<Umbraco.Core.Models.IContent> e)
        {
            if (ContentTypeAliases.Contains(e.Entity.ContentType.Alias))
                MethodToBind.Invoke(null, new object[] { sender, e });
        }
        #endregion

        #region RollingBack
        public void RollingBack(MethodInfo methodInfo, UmbracoEventAttribute attribute)
        {
            if (attribute.ContentTypeAliases.Any())
            {
                ContentTypeAliases = attribute.ContentTypeAliases;
                MethodToBind = methodInfo;
                ContentService.RollingBack += Filtered_RollingBack;
            }
            else
            {
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(ContentService), "RollingBack", methodInfo);
            }
        }

        void Filtered_RollingBack(IContentService sender, Umbraco.Core.Events.RollbackEventArgs<Umbraco.Core.Models.IContent> e)
        {
            if (ContentTypeAliases.Contains(e.Entity.ContentType.Alias))
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
                ContentService.Saved += Filtered_Saved;
            }
            else
            {
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(ContentService), "Saved", methodInfo);
            }
        }

        void Filtered_Saved(IContentService sender, Umbraco.Core.Events.SaveEventArgs<Umbraco.Core.Models.IContent> e)
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
                ContentService.Saving += Filtered_Saving;
            }
            else
            {
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(ContentService), "Saved", methodInfo);
            }
        }

        void Filtered_Saving(IContentService sender, Umbraco.Core.Events.SaveEventArgs<Umbraco.Core.Models.IContent> e)
        {
            if (e.SavedEntities.Select(c => c.ContentType.Alias).Intersect(ContentTypeAliases).Any())
                MethodToBind.Invoke(null, new object[] { sender, e });
        }
        #endregion

        #region SentToPublish
        public void SentToPublish(MethodInfo methodInfo, UmbracoEventAttribute attribute)
        {
            if (attribute.ContentTypeAliases.Any())
            {
                ContentTypeAliases = attribute.ContentTypeAliases;
                MethodToBind = methodInfo;
                ContentService.SentToPublish += Filtered_SentToPublish;
            }
            else
            {
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(ContentService), "SentToPublish", methodInfo);
            }
        }

        void Filtered_SentToPublish(IContentService sender, Umbraco.Core.Events.SendToPublishEventArgs<Umbraco.Core.Models.IContent> e)
        {
            if (ContentTypeAliases.Contains(e.Entity.ContentType.Alias))
                MethodToBind.Invoke(null, new object[] { sender, e });
        }
        #endregion

        #region SendingToPublish
        public void SendingToPublish(MethodInfo methodInfo, UmbracoEventAttribute attribute)
        {
            if (attribute.ContentTypeAliases.Any())
            {
                ContentTypeAliases = attribute.ContentTypeAliases;
                MethodToBind = methodInfo;
                ContentService.SendingToPublish += Filtered_SendingToPublish;
            }
            else
            {
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(ContentService), "SendingToPublish", methodInfo);
            }
        }

        void Filtered_SendingToPublish(IContentService sender, Umbraco.Core.Events.SendToPublishEventArgs<Umbraco.Core.Models.IContent> e)
        {
            if (ContentTypeAliases.Contains(e.Entity.ContentType.Alias))
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
                ContentService.Trashed += Filtered_Trashed;
            }
            else
            {
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(ContentService), "Trashed", methodInfo);
            }
        }

        void Filtered_Trashed(IContentService sender, Umbraco.Core.Events.MoveEventArgs<Umbraco.Core.Models.IContent> e)
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
                ContentService.Trashing += Filtered_Trashing;
            }
            else
            {
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(ContentService), "Trashing", methodInfo);
            }
        }

        void Filtered_Trashing(IContentService sender, Umbraco.Core.Events.MoveEventArgs<Umbraco.Core.Models.IContent> e)
        {
            if (e.MoveInfoCollection.Select(c => c.Entity.ContentType.Alias).Intersect(ContentTypeAliases).Any())
                MethodToBind.Invoke(null, new object[] { sender, e });
        }
        #endregion

        #region Unpublished
        public void Unpublished(MethodInfo methodInfo, UmbracoEventAttribute attribute)
        {
            if (attribute.ContentTypeAliases.Any())
            {
                ContentTypeAliases = attribute.ContentTypeAliases;
                MethodToBind = methodInfo;
                ContentService.UnPublished += Filtered_UnPublished;
            }
            else
            {
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(ContentService), "UnPublished", methodInfo);
            }
        }

        void Filtered_UnPublished(Umbraco.Core.Publishing.IPublishingStrategy sender, Umbraco.Core.Events.PublishEventArgs<Umbraco.Core.Models.IContent> e)
        {
            if (e.PublishedEntities.Select(c => c.ContentType.Alias).Intersect(ContentTypeAliases).Any())
                MethodToBind.Invoke(null, new object[] { sender, e });                                    
        }
        #endregion

        #region Unpublished
        public void Unpublishing(MethodInfo methodInfo, UmbracoEventAttribute attribute)
        {
            if (attribute.ContentTypeAliases.Any())
            {
                ContentTypeAliases = attribute.ContentTypeAliases;
                MethodToBind = methodInfo;
                ContentService.UnPublishing += Filtered_UnPublishing;
            }
            else
            {
                var eventBinder = new EventBinder();
                eventBinder.BindToEvent(typeof(ContentService), "UnPublishing", methodInfo);
            }
        }

        void Filtered_UnPublishing(Umbraco.Core.Publishing.IPublishingStrategy sender, Umbraco.Core.Events.PublishEventArgs<Umbraco.Core.Models.IContent> e)
        {
            if (e.PublishedEntities.Select(c => c.ContentType.Alias).Intersect(ContentTypeAliases).Any())
                MethodToBind.Invoke(null, new object[] { sender, e });  
        }
        #endregion
    }
}