using System;
using TwitchLib.Interfaces;
using TwitchLib.Models.API.v5.Users;

namespace NuffLib.Core.Models
{
  public class TwitchFollower : TwitchUser
  {
    public DateTime FollowedAt { get; }

    internal TwitchFollower(IUser user, DateTime followedAt)
      : base(user)
    {
      FollowedAt = followedAt;
    }
  }
}