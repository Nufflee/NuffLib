using System;
using TwitchLib.Enums;

namespace NuffLib.Core.Enums
{
  /// <summary>
  /// User levels
  /// </summary>
  public enum TwitchUserLevel
  {
    Unknown,
    Viewer,
    Subscriber,
    Moderator,
    GlobalModerator,
    Staff,
    Admin,
    Broadcaster
  }

  public static class TwitchUserLevelExtensions
  {
    internal static TwitchUserLevel GetUserLevel(this TwitchUserLevel userLevel, UserType userType)
    {
      switch (userType)
      {
        case UserType.Viewer:
          return TwitchUserLevel.Viewer;
        case UserType.Moderator:
          return TwitchUserLevel.Moderator;
        case UserType.GlobalModerator:
          return TwitchUserLevel.GlobalModerator;
        case UserType.Staff:
          return TwitchUserLevel.Staff;
        case UserType.Admin:
          return TwitchUserLevel.Admin;
        case UserType.Broadcaster:
          return TwitchUserLevel.Broadcaster;
        default:
          throw new ArgumentOutOfRangeException(nameof(userType), userType, null);
      }
    }

    internal static TwitchUserLevel GetUserLevel(UserType userType)
    {
      return GetUserLevel(0, userType);
    }
  }
}