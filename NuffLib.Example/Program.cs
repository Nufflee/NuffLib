using System;
using NuffLib.Core.Models;
using TwitchLib;

namespace NuffLib.Example
{
  public static class Program
  {
    //https://pastebin.com/Y6iudLGi
    private static void Main(string[] args)
    {
      TwitchAPI.Settings.Validators.SkipDynamicScopeValidation = true;

      TwitchBot bot = new TwitchBot(new TwitchCredentials(TwitchInfo.BotUsername, TwitchInfo.BotOAuth, TwitchInfo.BotClientId), TwitchInfo.ChannelName);
      bot.OnJoinedChannel += (b, e) =>
      {
        b.SendMessage("I joined!");
        Console.WriteLine(new TwitchChannel("pikkufighter").ProfileBannerUrl);
      };
      bot.OnMessageRecieved += (b, e) =>
      {
        Console.WriteLine($"{e.message}");
        bot.JoinedChannel.SetTitle(e.message.Text);
      };

      Console.ReadLine();
    }
  }
}