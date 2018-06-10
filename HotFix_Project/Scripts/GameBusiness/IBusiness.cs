namespace GameBusiness
{
    using GameBase;
    using GameUtil;
    using System;

    public interface IBusiness : ICoreModules, IInitialize, IDisposable,IUpdate,ILateUpdate
    {
        int refCount { get; set; }
        ICoreUtil Core { get; }
        BusinessCollection businessCollection { get; set; }

        void OnStart();
        void OnEnd();
    }
}
