namespace GameUI
{
    using GameUtil;
    using Modules;

    public interface IBaseView : ICore, IInitialize, IDisposable
    {
        UIType ViewType { get; set; }
        IMonoUI monoUI { get; set; }
        IModulesCollection CoreModules { get; set; }
        void OnEnter();
        void OnExit();
        void OnPause();
        void OnResume();
    }
}
