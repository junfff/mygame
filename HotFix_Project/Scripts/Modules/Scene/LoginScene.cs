namespace Modules.Scene
{
    using GameBusiness;
    using UnityEngine;

    public class LoginScene : BaseScene
    {
        public override void Initialize()
        {
            base.Initialize();
            base.AddBusiness<LoginBusiness>();
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
