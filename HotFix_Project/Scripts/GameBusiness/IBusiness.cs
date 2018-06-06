namespace GameBusiness
{
    using GameBase;
    using GameUtil;
    using Modules;
    using System;

    public interface IBusiness : ICoreModules, IInitialize, IDisposable
    {
        int refCount { get; set; }
        ICoreUtil Core { get; }
        BusinessCollection businessCollection { get; set; }

        void OnStart();
        void OnEnd();
    }
}
