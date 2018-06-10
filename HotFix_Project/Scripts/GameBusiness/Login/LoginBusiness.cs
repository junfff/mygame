namespace GameBusiness
{
    using System;
    using GameBase;
    using GameScene;
    using GameTimer;
    using GameUI;
    using UnityEngine;

    public class LoginBusiness : BaseBusiness<LoginViewModel>, IUpdate
    {
        private ITimer timer;
        public override void OnStart()
        {
            base.OnStart();
            base.Core.UI.Show(UIDefine.LoginView);
            base.Subscribe(base.viewModel.Define_StartButton, OnStartButton);
            base.Subscribe(base.viewModel.Define_LoginButton, OnLoginButton);

            timer = base.timerHandler.AddTimer(1000, OnTime, true);
        }
        public override void OnEnd()
        {
            base.OnEnd();
            base.UnSubscribe(base.viewModel.Define_StartButton, OnStartButton);
            base.UnSubscribe(base.viewModel.Define_LoginButton, OnLoginButton);


            base.timerHandler.RemoveTimer(timer);
        }
        private void OnTime(int passedTime)
        {
            Debug.LogErrorFormat("OnTime passedTime = {0}", passedTime);
            base.viewModel.LoginState.Value = string.Format("Start Connecting...{0}\n", passedTime) + base.viewModel.LoginState.Value;
        }
        private void OnStartButton(object param)
        {
            base.CoreModules.sceneMDL.RunScene(SceneType.Lobby);
        }
        private void OnLoginButton(object param)
        {
            start = true;
            base.viewModel.LoginState.Value = "Start Connecting...\n";
        }

        private int num = 0;
        public override void OnUpdate(float elapse)
        {
            if (start && num % 100 == 0)
            {
                base.viewModel.LoginState.Value = string.Format("Start Connecting...{0}\n", num) + base.viewModel.LoginState.Value;
            }
            num++;
        }

        private bool start;
    }
}
