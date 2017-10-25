using TwitchLib.Models.API.v5.Bits;

namespace NuffLib.Core.Models.Cheers
{
  public class TwitchCheerImages
  {
    public Image Light { get; }
    public Image Dark { get; }

    private readonly Images images;

    internal TwitchCheerImages(Images images)
    {
      this.images = images;

      Light = new Image(images.Light);
      Dark = new Image(images.Dark);
    }

    public struct Image
    {
      public ImageLinks Static { get; }
      public ImageLinks Animated { get; }

      internal Image(LightImage lightImage)
      {
        Static = new ImageLinks(lightImage.Static);
        Animated = new ImageLinks(lightImage.Animated);
      }

      internal Image(DarkImage darkImage)
      {
        Static = new ImageLinks(darkImage.Static);
        Animated = new ImageLinks(darkImage.Animated);
      }
    }

    public struct ImageLinks
    {
      public string One { get; }
      public string OnePointFive { get; }
      public string Two { get; }
      public string Three { get; }
      public string Four { get; }

      internal ImageLinks(TwitchLib.Models.API.v5.Bits.ImageLinks imageLinks)
      {
        One = imageLinks.One;
        OnePointFive = imageLinks.OnePointFive;
        Two = imageLinks.Two;
        Three = imageLinks.Three;
        Four = imageLinks.Four;
      }
    }
  }
}