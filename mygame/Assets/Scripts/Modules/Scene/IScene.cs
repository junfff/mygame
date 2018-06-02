namespace Modules.Scene
{
    public interface IScene : IUpdate, ILateUpdate, IInitialize, IDisposable, ICoreModules
    {
        SceneType sceneType { get; }
        SceneStep sceneStep { get; set; }
        void OnLoad();
        void OnUnLoad();
        void OnStart();
        void OnEnd();
        void OnNextStep();
    }
}