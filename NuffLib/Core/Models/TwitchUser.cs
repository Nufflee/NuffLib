﻿using System;
using System.Drawing;
using System.Linq;
using NuffLib.Core.Enums;
using TwitchLib;
using TwitchLib.Models.API.v5.Users;

namespace NuffLib.Core.Models
{
  public class TwitchUser
  {
    /// <summary>
    /// User's display name (case sensitive)
    /// </summary>
    public string DisplayName => user.DisplayName;

    /// <summary>
    /// User's username (not case sensitive)
    /// </summary>
    public string Username => user.Name;

    /// <summary>
    /// User's level
    /// </summary>
    public TwitchUserLevel Level => TwitchUserLevelExtensions.GetUserLevel(TwitchAPI.Undocumented.GetChattersAsync(JoinedTwitchChannel.Current.Name).Result.FirstOrDefault(c => c.Username == Username).UserType);

    /// <summary>
    /// User's logo url
    /// </summary>
    public string LogoUrl => user.Logo;

    /// <summary>
    /// User's ID
    /// </summary>
    public string Id => user.Id;

    /// <summary>
    /// Date when user's account was created
    /// </summary>
    public DateTime CreatedAt => user.CreatedAt;

    /// <summary>
    /// Users biography
    /// </summary>
    public string Bio => user.Bio;

    /// <summary>
    /// Date when user's account has been updated
    /// </summary>
    public DateTime UpdateAt => user.UpdatedAt;

    /// <summary>
    /// User's chat color
    /// </summary>
    public Color Color => Color.FromName(TwitchAPI.Undocumented.GetChatUser(Id, JoinedTwitchChannel.Current.Id).Result.Color);

    private readonly User user;

    /// <summary>
    /// Creates new instance of TwitchUser
    /// </summary>
    /// <param name="username">User's username</param>
    public TwitchUser(string username)
    {
      user = TwitchAPI.Users.v5.GetUserByNameAsync(username).Result.Matches[0];
    }

    internal TwitchUser(User user)
    {
      this.user = user;
    }

    /// <summary>
    /// Gets user by ID
    /// </summary>
    /// <param name="id">User's ID</param>
    /// <returns></returns>
    public static TwitchUser GetById(string id)
    {
      return new TwitchUser(TwitchAPI.Users.v5.GetUserByIDAsync(id).Result);
    }

    public override string ToString()
    {
      return DisplayName;
    }
  }
}