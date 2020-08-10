using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Impsbl.Infrastructure.Screens
{
    public sealed class GameBuilder
    {
        public string ContentRootDirectory = "Content";
        private readonly IList<Type> _registeredScreens = new List<Type>();
        private readonly IServiceCollection _serviceCollection = new ServiceCollection();

        public GameBuilder AddStateHolder<T>()
            where T : class
        {
            _serviceCollection.AddScoped<T>();
            return this;
        }

        public GameBuilder AddScreen<T>()
            where T : Screen
        {
            _serviceCollection.AddScoped<T>();
            _registeredScreens.Add(typeof(T));
            return this;
        }

        public GameBuilder AddScopedContentPack<T>()
            where T : class, IContentPack
        {
            _serviceCollection.AddScoped<T>();
            return this;
        }

        public GameBuilder AddSharedContentPack<T>()
            where T: class, IContentPack
        {
            _serviceCollection.AddSingleton<T>();
            return this;
        }

        public GameBuilder UseContentRootDirectory(string path)
        {
            ContentRootDirectory = path;
            return this;
        }

        public GameBuilder UseDefaultTransitioner()
        {
            _serviceCollection.AddSingleton<ITransitioner>(sp => new DefaultTransitioner(_registeredScreens.ToDictionary(sc => sc.Name, sc => sc), sp));
            return this;
        }

        public Game Build()
        {
            _serviceCollection.AddSingleton(sp => new ScreensCurator(sp.GetRequiredService<ITransitioner>(), ContentRootDirectory));
            _serviceCollection.AddSingleton(sp => sp.GetRequiredService<ScreensCurator>().Content);
            _serviceCollection.AddSingleton(sp => sp.GetRequiredService<ScreensCurator>().SpriteBatch);
            _serviceCollection.AddSingleton(sp => sp.GetRequiredService<ScreensCurator>().GraphicsDeviceManager);

            return _serviceCollection
                .BuildServiceProvider()
                .GetRequiredService<ScreensCurator>();
        }
    }
}
