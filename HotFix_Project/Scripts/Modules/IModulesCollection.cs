namespace Modules
{
    using GameBusiness;
    using Modules.Scene;
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
    }
}