using System;
using NuffLib.Core.Models;

namespace NuffLib.Core.Events
{
  public class UserBannedEventArgs : EventArgs
  {
    public TwitchUser user;
    public TwitchChannel channel;
    public string reason;

    public UserBannedEventArgs(string username, string channel, string reason)
    {
      user = new TwitchUser(username);
      this.channel = new TwitchChannel(channel);
      this.reason = reason;
    }
  }
}