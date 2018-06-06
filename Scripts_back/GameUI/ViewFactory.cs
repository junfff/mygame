using System;
using UnityEngine;

namespace GameUI
{
    public static class ViewFactory
    {
        public static IBaseView CreateView(int panelId)
        {
            switch (panelId)
            {
                case UIDefine.LobbyMainView:
                    return new MainMenuView();
                case UIDefine.SetupView:
                    return new SetupView();
                case UIDefine.LoginView:
                    return new LoginView();
            }
            Debug.LogErrorFormat("ViewFactory Create error !!!");
            return null;
        }

        public static UIType GetViewType(int panelId)
        {
            switch (panelId)
            {
                case UIDefine.LobbyMainView:
                    return UIDefine.MainMenu;
                case UIDefine.SetupView:
                    return UIDefine.Setup;
                case UIDefine.LoginView:
                    return UIDefine.Login;
            }
            Debug.LogErrorFormat("ViewFactory Create error !!!");
            return null;
        }
    }
}
