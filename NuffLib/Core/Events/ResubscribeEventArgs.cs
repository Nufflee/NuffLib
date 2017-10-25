using System;
using NuffLib.Core.Models;
using TwitchLib.Models.Client;

namespace NuffLib.Core.Events
{
  public class ReSubscribeEventArgs : EventArgs
  {
    public TwitchReSubscriber reSubscriber;

    public ReSubscribeEventArgs(ReSubscriber reSubscriber)
    {
      this.reSubscriber = new TwitchReSubscriber(reSubscriber);
    }
  }
}