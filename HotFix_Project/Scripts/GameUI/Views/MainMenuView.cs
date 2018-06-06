using uMVVM.Sources.Infrastructure;
using uMVVM.Sources.ViewModels;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class MainMenuView : BaseView<LobbyMainViewModel>
    {

        public override void OnEnter()
        {
            base.OnEnter();

           // Debug.LogErrorFormat("MainMenuView Enter!");
        }

        public override void OnExit()
        {
            base.OnExit();
        }



        public void OptionCallBack()
        {
            base.Core.UI.Show(UIDefine.SetupView);
        }

        public void HighScoreCallBack()
        {
            //Singleton<ContextManager>.Instance.Push(new HighScoreContext());
        }
        public void OnExitButton()
        {
            base.Core.UI.BackPage();
        }
    }
}
