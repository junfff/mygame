namespace GameBusiness
{
    using GameUtil;
    using Modules;
    using Modules.Scene;

    public interface IBusiness : ICoreModules, IInitialize, IDisposable
    {
        int refCount { get; set; }
        ICoreUtil Core { get; }
        BusinessCollection businessCollection { get; set; }

        void OnStart();
        void OnEnd();
    }
}
