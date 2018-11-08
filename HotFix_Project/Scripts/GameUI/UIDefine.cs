namespace GameUI
{
    public static class UIDefine
    {
        public const string SceneUIUtil = "Prefabs/SceneUIUtil";

        public const int LobbyMainView = 0; 
        public const int SetupView = 1; 
        public const int LoginView = 2; 
        public const int LoginAccount = 3;
        public const int LoginRegister = 4;
        public const int WindowHint = 5;

        public static readonly UIType MainMenu = new UIType("Prefabs/UI/MainMenuView", LobbyMainView);
        public static readonly UIType Setup = new UIType("Prefabs/UI/SetupView", SetupView);

        public static readonly UIType Login = new UIType("Prefabs/UI/Login/LoginView", LoginView);
        public static readonly UIType UILoginAccount = new UIType("Prefabs/UI/Login/LoginAccount", LoginAccount);
        public static readonly UIType UILoginRegister = new UIType("Prefabs/UI/Login/LoginRegister", LoginRegister);
        public static readonly UIType UIWindowHint = new UIType("Prefabs/UI/Common/WindowHint", WindowHint);

    }
}
