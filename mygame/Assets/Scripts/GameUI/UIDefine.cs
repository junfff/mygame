namespace GameUI
{
    public static class UIDefine
    {
        public const string SceneUIUtil = "Prefabs/SceneUIUtil";

        public const int MainView = 0; 
        public const int SetupView = 1; 
        public const int LoginView = 2; 

        public static readonly UIType MainMenu = new UIType("Prefabs/UI/MainMenuView", MainView);
        public static readonly UIType Setup = new UIType("Prefabs/UI/SetupView", SetupView);

        public static readonly UIType Login = new UIType("Prefabs/UI/Login/LoginView", LoginView);

    }
}
