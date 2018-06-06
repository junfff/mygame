namespace GameUI
{
    public interface IMonoUI
    {
        UIStyle uiStyle { get; }
        void Initialize();
        void OnEnter();
        void OnExit();
        void OnPause();
        void OnResume();
        AutoBinding[] GetAutoBinding();
    }
}
