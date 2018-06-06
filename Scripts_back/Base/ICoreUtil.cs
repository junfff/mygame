
namespace GameUtil
{
    using Modules.Scene;
    /// <summary>
    /// 核心工具集
    /// </summary>
    public interface ICoreUtil: IInitialize, IDisposable
    {
        SceneType sceneType { get; }
        IUIUtil UI { get; }
    }
}