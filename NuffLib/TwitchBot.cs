using NuffLib.Core.Events;
using NuffLib.Core.Models;
using NuffLib.Infrastructure;
using TwitchLib;
using TwitchLib.Interfaces;
using TwitchLib.Services;

namespace NuffLib
{
  public class TwitchBot
  {
    private TwitchClient client;

    /// <summary>
    /// Channel that bot is currently in
    /// </summary>
    public JoinedTwitchChannel JoinedChannel { get; private set; }

    public ITwitchAPI Api { get; }

    /// <summary>
    /// Static instance of the bot thats currently running
    /// </summary>
    public static TwitchBot Instance { get; private set; }

    /// <summary>
    /// Bot's connection credentials
    /// </summary>
    public TwitchCredentials Credentials { get; private set; }

    /// <summary>
    /// Executes when bot joins a channel
    /// </summary>
    public event TwitchBotEventHandler<JoinedChannelEventArgs> OnJoinedChannel;

    /// <summary>
    /// Executes when a message is sent in the channel that bot is currently in
    /// </summary>
    public event TwitchBotEventHandler<MessageRecievedEventArgs> OnMessageRecieved;

    /// <summary>
    /// Executes when bot leaves the channel it is in 
    /// </summary>
    public event TwitchBotEventHandler<LeftChannelEventArgs> OnLeftChannel;

    /// <summary>
    /// Executes when the channel that bot is in gets hosted
    /// </summary>
    public event TwitchBotEventHandler<BeingHostedEventArgs> OnBeingHosted;

    /// <summary>
    /// Executes when the bot receives a whisper
    /// </summary>
    public event TwitchBotEventHandler<WhisperReceivedEventArgs> OnWhisperRecieved;

    /// <summary>
    /// Executes when an unhandled exception happens
    /// </summary>
    public event TwitchBotEventHandler<UnhandledExceptionEventArgs> OnUnhandledException;

    /// <summary>
    /// Executes when channel that bot is currently in gets a new subscriber
    /// </summary>
    public event TwitchBotEventHandler<NewSubscriberEventArgs> OnNewSubscriber;

    /// <summary>
    /// Executres when user resubscribes
    /// </summary>
    public event TwitchBotEventHandler<ReSubscribeEventArgs> OnReSubscribe;

    public event TwitchBotEventHandler<NewFollowerEventArgs> OnNewFollower;

    /// <summary>
    /// Executes when user is banned
    /// </summary>
    public event TwitchBotEventHandler<UserBannedEventArgs> OnUserBanned;

    /// <summary>
    /// Executes when a message is logged to the console
    /// </summary>
    public event TwitchBotEventHandler<LogEventArgs> OnLog;

    /// <summary>
    /// Executes when user is timed out
    /// </summary>
    public event TwitchBotEventHandler<UserTimedOutEventArgs> OnUserTimedOut;

    /// <summary>
    /// Constructs a new instance of TwitchBot.
    /// </summary>
    /// <param name="credentials">Bot's credentials.</param>
    /// <param name="channel">Channel to join (if null bot doesn't join any channel).</param>
    /// <param name="log">Wether the bot should log it's activity.</param>
    /// <param name="autoReListenOnExceptions">Wether the bot should start back up after an unhandled exception.</param>
    public TwitchBot(TwitchCredentials credentials, string channel, bool log = false, bool autoReListenOnExceptions = true)
    {
      Credentials = credentials;

      client = new TwitchClient(credentials, channel, logging: log, autoReListenOnExceptions: autoReListenOnExceptions);
      Api = new TwitchAPI(credentials.ClientId, credentials.OAuthToken);
      Api.Settings.ClientId = credentials.ClientId;

      Instance = this;

      if (channel != null)
      {
        JoinedChannel = new JoinedTwitchChannel(channel);
      }

      GlobalExceptionHandler.OnUnhandledException += (sender, e) => OnUnhandledException?.Invoke(this, e);
      client.OnJoinedChannel += (sender, e) =>
      {
        OnJoinedChannel?.Invoke(this, new JoinedChannelEventArgs(new JoinedTwitchChannel(e.Channel)));
        JoinedChannel = new JoinedTwitchChannel(e.Channel);
      };
      client.OnMessageReceived += (sender, e) => OnMessageRecieved?.Invoke(this, new MessageRecievedEventArgs(new TwitchChatMessage(e.ChatMessage)));
      client.OnLeftChannel += (sender, e) => OnLeftChannel?.Invoke(this, new LeftChannelEventArgs(new JoinedTwitchChannel(e.Channel)));
      //client.OnBeingHosted += (sender, e) => OnBeingHosted?.Invoke(this, new BeingHostedEventArgs(new TwitchChannel(e.Channel), new TwitchChannel(e.HostedByChannel), e.Viewers, e.IsAutoHosted));
      client.OnNewSubscriber += (sender, e) => OnNewSubscriber?.Invoke(this, new NewSubscriberEventArgs(e.Subscriber, new JoinedTwitchChannel(e.Channel)));
      client.OnReSubscriber += (sender, e) => OnReSubscribe?.Invoke(this, new ReSubscribeEventArgs(e.ReSubscriber));
      client.OnWhisperReceived += (sender, e) => OnWhisperRecieved?.Invoke(this, new WhisperReceivedEventArgs(e.WhisperMessage));
      client.OnUserBanned += (sender, e) => OnUserBanned?.Invoke(this, new UserBannedEventArgs(e.Username, new JoinedTwitchChannel(e.Channel), e.BanReason));
      client.OnLog += (sender, e) => OnLog?.Invoke(this, new LogEventArgs(e.Data, e.DateTime));
      client.OnUserTimedout += (sender, e) => OnUserTimedOut?.Invoke(this, new UserTimedOutEventArgs(new JoinedTwitchChannel(e.Channel), new TwitchUser(e.Username), e.TimeoutDuration, e.TimeoutReason));

      StartFollowerService();

      client.Connect();
    }

    ~TwitchBot()
    {
      Instance = null;
    }

    private async void StartFollowerService()
    {
      FollowerService followerService = new FollowerService(Api, clientId: Credentials.ClientId);

      followerService.SetChannelByChannelId(JoinedChannel.Id);
      await followerService.StartService();

      followerService.OnNewFollowersDetected += (sender, args) =>
      {
        foreach (IFollow follow in args.NewFollowers)
        {
          OnNewFollower.Invoke(this, new NewFollowerEventArgs(JoinedChannel, follow));
        }
      };
    }

    /// <summary>
    /// Sends chat message.
    /// </summary>
    /// <param name="message">The message to be sent.</param>
    /// <param name="dryRun">For testing, if true the message wont actually be sent.</param>
    public void SendMessage(string message, bool dryRun = false)
    {
      client.SendMessage(message, dryRun);
    }

    /// <summary>
    /// Sends whisper message to the <paramref name="reciever"/>.
    /// </summary>
    /// <param name="reciever">User to recieve the whisper message.</param>
    /// <param name="message">The message to be sent.</param>
    /// <param name="dryRun">For testing, if true the message wont actually be sent.</param>
    public void SendWhisper(TwitchUser reciever, string message, bool dryRun = false)
    {
      client.SendWhisper(reciever.Username, message, dryRun);
    }
  }
}