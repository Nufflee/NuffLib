using System;
using NuffLib.Core.Models;
using TwitchLib.Models.Client;

namespace NuffLib.Core.Events
{
  public class NewSubscriberEventArgs : EventArgs
  {
    public TwitchSubscriber subscriber;
    public string message;
    public JoinedTwitchChannel channel;

    public NewSubscriberEventArgs(Subscriber subscriber, JoinedTwitchChannel channel)
    {
      this.subscriber = new TwitchSubscriber(subscriber);
      message = subscriber.ResubMessage;
      this.channel = channel;
    }
  }
}