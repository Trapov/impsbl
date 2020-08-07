using Impsbl.Content.SharedContent;
using Impsbl.Infrastructure.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Impsbl
{
    public class MainMenuScreen : Screen
    {
        public MainMenuScreen(
            SpriteBatch spriteBatch,
            GraphicsDeviceManager graphicsDeviceManager,
            ITransitioner transitioner,
            Fonts fonts) : base(spriteBatch, graphicsDeviceManager, transitioner)
        {
            SharedFonts = fonts;
            SharedFonts.Load();
        }

        public Fonts SharedFonts { get; }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDeviceManager.GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
            SpriteBatch.DrawString(
                SharedFonts.Default,
                "Press Enter to start the game...",
                new Vector2(100, 100),
                Color.White,
                0,
                new Vector2(100, 100),
                0.6f,
                SpriteEffects.None,
                0
            );
            SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                Transitioner.To(nameof(RoomScreen));
        }
    }
}
