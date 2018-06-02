namespace Modules.Scene
{

    public interface ISceneModules : IModules
    {
        IScene GetScene(SceneType type);
        int RunScene(SceneType type);
        int StopScene(SceneType type);
    }
}