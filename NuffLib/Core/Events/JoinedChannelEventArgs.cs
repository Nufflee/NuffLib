using System;
using NuffLib.Core.Models;

namespace NuffLib.Core.Events
{
  public class JoinedChannelEventArgs : EventArgs
  {
    public TwitchChannel channel;

    public JoinedChannelEventArgs(TwitchChannel channel)
    {
      this.channel = channel;
    }
  }
}