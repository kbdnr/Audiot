using Prism.Events;

namespace AudiotEvents
{
    /// <summary>
    /// Create PubSubEvents Here!
    /// </summary>
    public class TitleEvent : PubSubEvent<string> { }
    public class StartStatus : PubSubEvent<string> { }
    public class StatusMessageEvent : PubSubEvent<string> { }
    public class RestoreStatusMessageEvent : PubSubEvent { }

    public class PrintEvent : PubSubEvent { }
    public class NewEvent : PubSubEvent { }
    public class SaveEvent : PubSubEvent<string> { }
    public class HelpEvent : PubSubEvent<string> { }
    public class AboutEvent : PubSubEvent<string> { }

    public class ExitEvent : PubSubEvent<string> { }
    public class IconEvent : PubSubEvent<string> { }
}
