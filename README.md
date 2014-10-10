UmbracoAOP is a project looking into how Aspect Oriented Programming can be applied to general Umbraco tasks.  Such as subscribing to Umbraco events!

What is Event Subscriber?

Event Subscriber allows developers to easily subscribe to Umbraco events, without worrying about all the plumbing.  Currently, this tool allows you to subscribe to all ContentService events.  Event Subscriber also allows you to filter by content type alias when your function should be called.  More event implementations are on the way...

Here's how you would subscribe to the publish event with Event Subscriber:

public class BlogPost
{
    //run on all Saved events
    [UmbracoEvent]
    public static void WhenPublished(IPublishingStrategy sender, 
          Umbraco.Core.Events.PublishEventArgs<Umbraco.Core.Models.IContent> e)
    {
        //do something
    }

    //run only when a BlogPost is published
    [UmbracoEvent( "BlogPost" )]
    public static void BlogPost_OnPublished(IPublishingStrategy sender, 
          Umbraco.Core.Events.PublishEventArgs<Umbraco.Core.Models.IContent> e)
    {
        //do something
    }
}

 

Here's how you could subscribe to the publish event currently:

public class Startup : ApplicationEventHandler
{
    public Startup()
    {
        ContentService.Published += Published;
        ContentService.Published += FilteredPublished;
    }

    void Published(IPublishingStrategy sender, 
         Umbraco.Core.Events.PublishEventArgs<Umbraco.Core.Models.IContent> e)
    {
        //do something
    }

    void FilteredPublished(IPublishingStrategy sender, 
         Umbraco.Core.Events.PublishEventArgs<Umbraco.Core.Models.IContent> e)
    {
        if (e.PublishedEntities.Any(c => c.ContentType.Alias == "BlogPost" || 
                    c.ContentType.Alias == "BlogFolder"))
        {
            //do something
        }
    }
}

 

So how does it work?

Event Subscriber detects the method signature and a method suffix.  The suffix is the name of the event - for example Saved, Saving, Published, Publishing, Copied, Moved, etc.

For example


    [UmbracoEvent]
    public static void WhenSaved(IContentService sender, 
             Umbraco.Core.Events.SaveEventArgs<Umbraco.Core.Models.IContent> e)
    {
        //do something
    }

The function name is WhenSaved.  The beginning part of the method name can be named however you like.  It could be 'DoSomethingWhenSaved'.

The parameters must match the parameters required by the Umbraco Service events.  If you find an event isn't working, please check what parameters are required here:  our.umbraco.org/.../ContentService-Events

 

You can also specify when your event method should be called based on the Content Type alias. 

Here is an example of a method that should only be called when a BlogPost is unpublished:

    [UmbracoEvent ( "BlogPost" )]
    public static void BlogPost_OnUnpublished(IPublishingStrategy sender, 
               PublishEventArgs<IContent> e)
    {
        //do something
    }

 

You can also specify multiple types:

    [UmbracoEvent ( "BlogPost", "HomePage" )]
    public static void DoStuffWhenUnpublished(IPublishingStrategy sender, 
                PublishEventArgs<IContent> e)
    {
        //do something
    }

 

Why use Event Subscriber?

    Easy to learn
    No need to worry about which application startup to use
    Abstracts over the Umbraco API, making it easy to make updates in the future.
    Removes the need for various repeated if-statements to check for the correct type

 

You can install via NuGet:

PM> Install-Package UmbracoAOP.EventSubscriber

The source code is under MIT license.

You can contribute or download the source here:  https://github.com/base33/UmbracoAOP

 
