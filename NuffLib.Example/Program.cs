﻿using System;
using NuffLib.Core.Models;

namespace NuffLib.Example
{
  public static class Program
  {
    //https://pastebin.com/Y6iudLGi
    private static void Main(string[] args)
    {
      //TwitchAPI.Settings.Validators.SkipDynamicScopeValidation = true;

      TwitchBot bot = new TwitchBot(new TwitchCredentials(TwitchInfo.BotUsername, TwitchInfo.BotOAuth, TwitchInfo.BotClientId), TwitchInfo.ChannelName, log: true);
      bot.OnJoinedChannel += (b, e) =>
      {
        b.SendMessage("I joined!");
        Console.WriteLine(new TwitchChannel("pikkufighter").ProfileBannerUrl);
      };

      bot.OnLog += (twitchBot, eventArgs) => Console.WriteLine("This is the data \\o/ " + eventArgs.data);
      bot.OnNewFollower += (twitchBot, eventArgs) => Console.WriteLine($"{eventArgs.follower} just followed at {eventArgs.follower.FollowedAt}!");

      Console.ReadLine();
    }
  }
}