
namespace GameUtil
{
    using GameUI;
    using Modules;
    using System;

    public interface IUIUtil 
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
