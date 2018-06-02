using GameUI;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Modules.Scene
{
    public class LoginScene : BaseScene
    {
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


            base.coreUtil.UI.Show(UIDefine.LoginView);
        }

      
    }
}
