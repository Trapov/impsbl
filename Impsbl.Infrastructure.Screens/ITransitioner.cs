namespace Impsbl.Infrastructure.Screens
{
    public interface ITransitioner
    {
        Screen Current { get; }
        void To(string path);
    }
}
