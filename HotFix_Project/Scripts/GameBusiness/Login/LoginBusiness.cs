namespace GameBusiness
{
    using GameUI;
    using Modules.Scene;
    using uMVVM.Sources.ViewModels;
    using UnityEngine;

    public class LoginBusiness : BaseBusiness<LoginViewModel>
    {
        public override void OnStart()
        {
            base.OnStart();

            base.Core.UI.Show(UIDefine.LoginView);

            base.viewModel.messageAggregator.Subscribe(base.viewModel.Define_StartButton, OnStartButton);
        }

        private void OnStartButton(object param)
        {
            Debug.LogErrorFormat("OnStartButton param = {0}", (bool)param);
            base.CoreModules.sceneMDL.RunScene(SceneType.Lobby);
        }

        public override void OnEnd()
        {
            base.OnEnd();
            base.viewModel.messageAggregator.UnSubscribe(base.viewModel.Define_StartButton, OnStartButton);
        }
    }
}
