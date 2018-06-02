using System;
using UnityEngine;

namespace GameUI
{
    public static class ViewFactory
    {
        internal static IBaseView CreateView(int panelId)
        {
            switch (panelId)
            {
                case UIDefine.MainView:
                    return new MainMenuView();
                case UIDefine.SetupView:
                    return new SetupView();
                case UIDefine.LoginView:
                    return new LoginView();
            }
            Debug.LogErrorFormat("ViewFactory Create error !!!");
            return null;
        }
    }
}
