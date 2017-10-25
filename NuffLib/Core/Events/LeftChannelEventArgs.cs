using System;
using NuffLib.Core.Models;

namespace NuffLib.Core.Events
{
  public class LeftChannelEventArgs : EventArgs
  {
    public TwitchChannel channel;

    public LeftChannelEventArgs(TwitchChannel channel)
    {
      this.channel = channel;
    }
  }
}