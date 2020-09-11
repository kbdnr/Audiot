using AudiotLogic.MidiLogic;
using Prism.Events;
using Prism.Regions;
using System.Collections.Generic;

namespace AudiotEvents
{
    public class TitleEvent : PubSubEvent<string> { }
    public class StartStatus : PubSubEvent<string> { }
    public class StatusMessageEvent : PubSubEvent<string> { }
    public class RestoreStatusMessageEvent : PubSubEvent { }

    public class NewEvent : PubSubEvent { }
    public class SaveEvent : PubSubEvent<string> { }
    public class HelpEvent : PubSubEvent<string> { }
    public class AboutEvent : PubSubEvent<string> { }
    public class ExitEvent : PubSubEvent<string> { }
    public class IconEvent : PubSubEvent<string> { }

    public class InitializedEvent : PubSubEvent<bool> { }

    public class CreateControlLineEvent : PubSubEvent<IRegionManager> { }
    public class DeleteControlLineEvent : PubSubEvent { }
    public class UpdateControlParameters : PubSubEvent<List<ControlChange>> { }
}
