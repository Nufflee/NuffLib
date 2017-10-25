using TwitchLib.Models.Client;

namespace NuffLib.Core.Models
{
  public class TwitchSubscriber : TwitchSubscriberBase
  {
    internal TwitchSubscriber(Subscriber subscriber)
      : base(subscriber)
    {
    }
  }
}