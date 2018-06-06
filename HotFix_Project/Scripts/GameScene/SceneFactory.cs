namespace Modules.Scene
{

    public class SceneFactory
    {
        public static BaseScene Create(SceneType type)
        {
            switch (type)
            {
                case SceneType.Login:
                    return new LoginScene();
                case SceneType.Lobby:
                    return new LobbyScene();
            }

            return null;
        }
    }
}
