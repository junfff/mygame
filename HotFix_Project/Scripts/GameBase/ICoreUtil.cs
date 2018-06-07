
namespace GameUtil
{
    using GameBase;
    using GameScene;
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