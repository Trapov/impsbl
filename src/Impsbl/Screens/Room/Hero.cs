using Impsbl.Content;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;

namespace Impsbl.Screens.Room
{
    public sealed class Hero : IDisposable
    {
        private readonly HeroTextures _heroTextures;

        public Hero(HeroTextures heroTextures)
        {
            heroTextures.Load();
            _heroTextures = heroTextures;
            CurrentStateTexture = heroTextures.Standing;
        }

        public Point Coordinate { get; private set; } = new Point(0, 100);


        public Texture2D CurrentStateTexture { get; private set; }
        public void Dispose() => _heroTextures.Dispose();

        public void Update(KeyboardState keyboardState) =>
            Coordinate = keyboardState.GetPressedKeys().FirstOrDefault() switch
            {
                Keys.Right => new Point(Coordinate.X + 10, Coordinate.Y),
                Keys.Left => IfLeft(),
                Keys.Up => new Point(Coordinate.X, Coordinate.Y - 10),
                Keys.Down => IfDown(),
                _ => Coordinate
            };

        private Point IfLeft()
        {
            CurrentStateTexture = _heroTextures.Standing;
            return new Point(Coordinate.X - 10, Coordinate.Y);
        }

        private Point IfDown()
        {
            CurrentStateTexture = _heroTextures.Moving.Down;
            return new Point(Coordinate.X, Coordinate.Y + 10);
        }
    }
}
