namespace GameScene
{
    using GameBusiness;
    using GameScene;

    public class LoginScene : BaseScene
    {
        public override void Initialize()
        {
            base.Initialize();
            base.AddBusiness<LoginAccountBusiness>();
            base.AddBusiness<LoginBusiness>();
            base.AddBusiness<WindowHintBusiness>();
            base.AddBusiness<LoginRegisterBusiness>();
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
