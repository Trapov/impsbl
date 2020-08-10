using System;

namespace Impsbl.Infrastructure.Screens
{
    /// <summary>
    /// Holds a lot of unmanaged resources.
    /// </summary>
    public interface IContentPack : IDisposable
    {
        void Load();
    }
}
