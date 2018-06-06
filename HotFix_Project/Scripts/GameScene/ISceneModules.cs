namespace Modules.Scene
{

    public interface ISceneModules : IModules
    {
        IScene curScene { get; }
        IScene GetScene(SceneType type);
        int RunScene(SceneType type);
        int StopScene(SceneType type);
    }
}