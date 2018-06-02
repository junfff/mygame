
namespace GameUI
{
    using GameUtil;
    public interface IBaseView : ICore, IInitialize, IDisposable
    {
        UIType ViewType { get; set; }
        IMonoUI monoUI { get; set; }
        void OnEnter();
        void OnExit();
        void OnPause();
        void OnResume();
    }
}
