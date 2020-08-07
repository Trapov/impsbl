using Impsbl.Content;
using Impsbl.Content.SharedContent;
using Impsbl.Infrastructure.Screens;
using Impsbl.Screens.Room;
using System;

namespace Impsbl.Application
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using var game
                = new GameBuilder()
                    .AddSharedContentPack<Fonts>()
                    .AddSharedContentPack<HeroTextures>()
                    .AddStateHolder<Hero>()
                    .AddScreen<MainMenuScreen>()
                    .AddScreen<RoomScreen>()
                    .UseContentRootDirectory(Constants.ContentRootDirectory)
                    .UseDefaultTransitioner()
                    .Build();

            game.Run();
        }
    }
}
