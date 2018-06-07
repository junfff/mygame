namespace GameScene
{
    using GameBusiness;
    using GameScene;

    public class LobbyScene : BaseScene
    {
        public override void Initialize()
        {
            base.Initialize();
            base.AddBusiness<LobbyMainBusiness>();
        }
        public override SceneType sceneType
        {
            get
            {
                return SceneType.Login;
            }
        }
        public override void OnStart()
        {
            base.OnStart();
        }


    }
}
