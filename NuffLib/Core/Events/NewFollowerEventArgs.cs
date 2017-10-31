using System;
using NuffLib.Core.Models;
using TwitchLib.Interfaces;

namespace NuffLib.Core.Events
{
  public class NewFollowerEventArgs : EventArgs
  {
    public JoinedTwitchChannel channel;
    public TwitchFollower follower;

    public NewFollowerEventArgs(JoinedTwitchChannel channel, IFollow follow)
    {
      this.channel = channel;
      this.follower = new TwitchFollower(follow.User, follow.CreatedAt);
    }
  }
}