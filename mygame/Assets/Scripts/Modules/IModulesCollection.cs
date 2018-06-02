namespace Modules
{
    using Modules.Scene;
    /// <summary>
    /// 核心模块集
    /// </summary>
    public interface IModulesCollection : IInitialize, IDisposable, IUpdate, ILateUpdate
    {
        SceneUIUtil seneUnity { get; }
        ISceneModules sceneMDL { get; }
        IResModule resMDL { get; }
    }
}