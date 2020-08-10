using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Impsbl.Infrastructure.Screens
{
    public sealed class ScreensCurator : Game
    {
        private readonly ITransitioner _transitioner;
        internal SpriteBatch SpriteBatch { get; private set; }
        internal GraphicsDeviceManager GraphicsDeviceManager { get; }

        public ScreensCurator(ITransitioner transitioner, string contentRootDirectory)
        {
            Content.RootDirectory = contentRootDirectory;
            GraphicsDeviceManager = new GraphicsDeviceManager(this);
            _transitioner = transitioner;
        }

        protected override void Initialize()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            _transitioner.Current.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _transitioner.Current.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
