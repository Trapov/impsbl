using Impsbl.Content;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;

namespace Impsbl.Screens.Room
{
    public sealed class DrawingRequest 
    {
        public DrawingRequest(Texture2D texture, Vector2 vector, Rectangle rectangle, Color color)
        {
            Texture = texture;
            Vector = vector;
            Rectangle = rectangle;
            Color = color;
        }

        public Texture2D Texture { get; private set; }
        public Vector2 Vector { get; private set; }
        public Rectangle Rectangle { get; private set; }
        public Color Color {get; private set;}
    }

    public sealed class Hero : IDisposable
    {
        private readonly HeroTextures _heroTextures;

        public Hero(HeroTextures heroTextures)
        {
            heroTextures.Load();
            _heroTextures = heroTextures;
            CurrentStateTexture = new DrawingRequest(
                heroTextures.Standing.Texture,
                Coordinate.ToVector2(),
                heroTextures.Standing[0,1], Color.White
            );
        }

        public Point Coordinate { get; private set; } = new Point(0, 100);


        public DrawingRequest CurrentStateTexture { get; private set; }
        public void Dispose() => _heroTextures.Dispose();

        public void Update(KeyboardState keyboardState) =>
            Coordinate = keyboardState.GetPressedKeys().FirstOrDefault() switch
            {
                Keys.Right => IfRight(),
                Keys.Left => IfLeft(),
                Keys.Up => IfUp(),
                Keys.Down => IfDown(),
                _ => Coordinate
            };

        private Point IfUp()
        {
            CurrentStateTexture = new DrawingRequest(_heroTextures.Standing.Texture, Coordinate.ToVector2(), _heroTextures.Standing[0, _heroTextures.Moving.Down], Color.White);
            return new Point(Coordinate.X, Coordinate.Y - 10);
        }

        private Point IfRight()
        {
            CurrentStateTexture = new DrawingRequest(_heroTextures.Standing.Texture, Coordinate.ToVector2(), _heroTextures.Standing[3, _heroTextures.Moving.Down], Color.White);
            return new Point(Coordinate.X  + 10, Coordinate.Y);
        }

        private Point IfLeft()
        {
            CurrentStateTexture = new DrawingRequest(_heroTextures.Standing.Texture, Coordinate.ToVector2(), _heroTextures.Standing[1, _heroTextures.Moving.Down], Color.White);
            return new Point(Coordinate.X - 10, Coordinate.Y);
        }

        private Point IfDown()
        {
            CurrentStateTexture = new DrawingRequest(
                _heroTextures.Standing.Texture, Coordinate.ToVector2(), _heroTextures.Standing[2, _heroTextures.Moving.Down], Color.White
            );
            return new Point(Coordinate.X, Coordinate.Y + 10);
        }
    }
}
