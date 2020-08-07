using Impsbl.Infrastructure.Screens;
using Impsbl.Screens.Room;
using Impsbl.Content.SharedContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Impsbl
{
    public class RoomScreen : Screen
    {
        public RoomScreen(
            SpriteBatch spriteBatch,
            GraphicsDeviceManager graphicsDeviceManager,
            Hero hero,
            ITransitioner transitioner,
            Fonts fonts) : base(spriteBatch, graphicsDeviceManager, transitioner)
        {
            SharedFonts = fonts;
            Hero = hero;
            SharedFonts.Load();
        }

        public Hero Hero { get; private set; }
        public Fonts SharedFonts { get; private set; }

        public override void Draw(GameTime gameTime)
        {

            GraphicsDeviceManager.GraphicsDevice.Clear(Color.AliceBlue);

            SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
            SpriteBatch.Draw(Hero.CurrentStateTexture, new Rectangle(Hero.Coordinate.X, Hero.Coordinate.Y, 150, 150), Color.White);
            SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                Transitioner.To(nameof(MainMenuScreen));
            }

            Hero.Update(keyboardState);
        }
    }
}
