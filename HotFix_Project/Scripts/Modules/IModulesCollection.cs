namespace GameBase
{
    using GameBusiness;
    using GameNet;
    using GameRes;
    using GameTimer;
    using System;

    /// <summary>
    /// 核心模块集
    /// </summary>
    public interface IModulesCollection : IInitialize, IDisposable, IUpdate, ILateUpdate
    {
        SceneUIUtil seneUnity { get; }
        ISceneModules sceneMDL { get; }
        IResModule resMDL { get; }
        IBusinessModule busMDL { get; }
        INetModule netMDL { get; }
        ITimerModule timerMDL { get; }
    }
}