using Impsbl.Infrastructure.Screens;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace Impsbl.Content
{
    public sealed class HeroTextures : IContentPack
    {
        private readonly ContentManager _contentManager;

        public HeroTextures(ContentManager contentManager)
        {
            _contentManager = contentManager;
            //_contentManager.Load
            Moving = new MovingTextures(contentManager);
        }

        public Texture2D Standing { get; private set; }
        public MovingTextures Moving { get; }

        public sealed class MovingTextures : IContentPack
        {
            private readonly ContentManager _contentManager;

            private int _downIndex = 0;

            private Texture2D _down;
            private Texture2D _downLeftLeg;
            private Texture2D _downRightLeg;

            public MovingTextures(ContentManager contentManager) => _contentManager = contentManager;

            public Texture2D Down
            {
                get
                {
                    _downIndex = (_downIndex + 1) % 3;

                    return _downIndex switch
                    {
                        0 => _down,
                        1 => _downLeftLeg,
                        2 => _downRightLeg,
                        _ => throw new System.NotImplementedException()
                    };
                }
            }



            public void Dispose() => _contentManager.Unload();

            public void Load()
            {
                _down = _contentManager.Load<Texture2D>(Path.Combine(Constants.TexturesDirectory, "Hero", $"Moving.{nameof(Down)}"));
                _downLeftLeg = _contentManager.Load<Texture2D>(Path.Combine(Constants.TexturesDirectory, "Hero", $"Moving.{nameof(Down)}.LeftLeg"));
                _downRightLeg = _contentManager.Load<Texture2D>(Path.Combine(Constants.TexturesDirectory, "Hero", $"Moving.{nameof(Down)}.RightLeg"));
            }
        }

        public void Load()
        {
            Standing = _contentManager.Load<Texture2D>(Path.Combine(Constants.TexturesDirectory, "Hero", nameof(Standing)));
            Moving.Load();
        }

        public void Dispose() => _contentManager.Unload();
    }
}
