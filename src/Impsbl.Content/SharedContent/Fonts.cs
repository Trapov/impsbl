using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System.IO;

using Impsbl.Infrastructure.Screens;

namespace Impsbl.Content.SharedContent
{
    public sealed class Fonts : IContentPack
    {
        private readonly ContentManager _contentManager;
        public SpriteFont Default { get; private set; }

        public Fonts(ContentManager contentManager) => _contentManager = contentManager;

        public void Load() => Default = _contentManager.Load<SpriteFont>(Path.Combine(Constants.FontsDirectory, nameof(Default)));
        public void Dispose() => _contentManager.Unload();
    }
}
