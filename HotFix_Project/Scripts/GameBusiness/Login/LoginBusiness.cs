namespace GameBusiness
{
    using System;
    using GameBase;
    using GameNet;
    using GameScene;
    using GameTimer;
    using GameUI;
    using UnityEngine;

    public class LoginBusiness : BaseBusiness<LoginViewModel>, IUpdate
    {
        public override void OnStart()
        {
            base.OnStart();
            base.Core.UI.Show(UIDefine.LoginView);
            base.Subscribe(base.viewModel.Define_StartButton, OnStartButton);
            base.Subscribe(base.viewModel.Define_LoginButton, OnLoginButton);
            base.Subscribe(base.viewModel.Define_SendButton, OnSendButton);

            //base.timerHandler.AddTimer(1000, OnTime);
        }
        public override void OnEnd()
        {
            base.OnEnd();
            base.UnSubscribe(base.viewModel.Define_StartButton, OnStartButton);
            base.UnSubscribe(base.viewModel.Define_LoginButton, OnLoginButton);
            base.UnSubscribe(base.viewModel.Define_SendButton, OnSendButton);
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
            base.viewModel.LoginState.Value = "Start Connecting...\n";

            ServerInfo info = new ServerInfo();
            info.ip = "47.106.123.211";
            info.port = 33000;

            base.CoreModules.netMDL.ConnectServer(info, RomoteType.LOGIN);

        }
        private void OnSendButton(object param)
        {
            if(param is string)
            {
                string str = (string)param;
                if (string.IsNullOrEmpty(str))
                {
                    Debug.LogErrorFormat("OnSendButton str IsNullOrEmpty");
                    return;
                }
                BaseMessage msg = new BaseMessage();
                msg.obj = str;
                CoreModules.netMDL.SendMessage(msg);
                Debug.LogErrorFormat("OnSendButton str = {0}", str);
            }
      
        }
        public override void OnUpdate(float elapse)
        {
        }

    }
}
