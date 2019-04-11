namespace CastleFactoryExample.Interfaces
{
    public interface IMyFactory
    {
        IMyProvider CreateMyProvider(string s);
        void Release(IMyProvider myProvider);
    }
}
