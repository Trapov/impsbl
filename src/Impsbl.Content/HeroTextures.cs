using Impsbl.Infrastructure.Screens;
using Impsbl.Infrastructure.Spritesheets;
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
            Moving = new MovingTextures(contentManager);
        }

        public GridSheet Standing { get; private set; }
        public MovingTextures Moving { get; }

        public sealed class MovingTextures 
        {
            private readonly ContentManager _contentManager;

            private int _downIndex = 0;

            private GridSheet _down;

            public MovingTextures(ContentManager contentManager) => _contentManager = contentManager;

            public int Down
            {
                get
                {
                    _downIndex = (_downIndex + 1) % 3;
                    return _downIndex;
                }
            }
        }

        public void Load()
        {
            Standing = _contentManager.Load<GridSheet>(
                Path.Combine(Constants.TexturesDirectory, "Hero", "Spritesheet")
            );
        }

        public void Dispose() => _contentManager.Unload();
    }
}
