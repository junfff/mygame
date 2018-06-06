
namespace GameUtil
{
    using GameUI;
    using Modules;

    public interface IUIUtil : IDisposable, IInitialize, ICore, ICoreModules
    {
        IBaseView CreatePanel(int panelId);
        bool Show(int panelId);
        bool Hide(int panelId);
        bool IsShow(int panelId);
        void Back();
        void BackPageTo(int panelId);
        void BackPage();
    }
}
