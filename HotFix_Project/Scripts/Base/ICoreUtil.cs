
namespace GameUtil
{
    using GameBase;
    using Modules.Scene;
    using System;

    /// <summary>
    /// 核心工具集
    /// </summary>
    public interface ICoreUtil: IInitialize, IDisposable
    {
        SceneType sceneType { get; }
        IUIUtil UI { get; }
    }
}