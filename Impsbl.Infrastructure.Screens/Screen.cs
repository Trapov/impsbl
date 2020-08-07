using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Impsbl.Infrastructure.Screens
{
    public abstract class Screen
    {
        protected readonly SpriteBatch SpriteBatch;
        protected readonly GraphicsDeviceManager GraphicsDeviceManager;
        protected readonly ITransitioner Transitioner;

        protected Screen(
            SpriteBatch spriteBatch,
            GraphicsDeviceManager graphicsDeviceManager,
            ITransitioner transitioner
        )
        {
            SpriteBatch = spriteBatch;
            GraphicsDeviceManager = graphicsDeviceManager;
            Transitioner = transitioner;
        }


        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
    }
}
