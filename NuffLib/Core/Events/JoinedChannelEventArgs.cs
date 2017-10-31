using System;
using NuffLib.Core.Models;

namespace NuffLib.Core.Events
{
  public class JoinedChannelEventArgs : EventArgs
  {
    public JoinedTwitchChannel channel;

    public JoinedChannelEventArgs(JoinedTwitchChannel channel)
    {
      this.channel = channel;
    }
  }
}