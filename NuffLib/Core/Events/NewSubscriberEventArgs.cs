using System;
using NuffLib.Core.Models;
using TwitchLib.Models.Client;

namespace NuffLib.Core.Events
{
  public class NewSubscriberEventArgs : EventArgs
  {
    public TwitchSubscriber subscriber;
    public string message;
    public TwitchChannel channel;

    public NewSubscriberEventArgs(Subscriber subscriber, string channel)
    {
      this.subscriber = new TwitchSubscriber(subscriber);
      message = subscriber.ResubMessage;
      this.channel = new TwitchChannel(channel);
    }
  }
}