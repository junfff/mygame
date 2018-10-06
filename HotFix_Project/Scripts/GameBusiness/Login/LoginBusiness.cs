namespace GameBusiness
{
    using GameBase;
    using GameEvent;
    using GameNet;
    using GameScene;
    using GameUI;
    using Google.Protobuf;
    using System;
    using System.IO;
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

            base.CoreModules.eventMDL.Subscribe(DefineProtobuf.MSG_PERSON, OnPerson);
        }
        public override void OnEnd()
        {
            base.OnEnd();
            base.UnSubscribe(base.viewModel.Define_StartButton, OnStartButton);
            base.UnSubscribe(base.viewModel.Define_LoginButton, OnLoginButton);
            base.UnSubscribe(base.viewModel.Define_SendButton, OnSendButton);

            base.CoreModules.eventMDL.UnSubscribe(DefineProtobuf.MSG_PERSON, OnPerson);
        }

        private void OnPerson(object param)
        {
            if (param is Person)
            {
                Person p = param as Person;
                Debug.LogErrorFormat(">>>> LoginBusiness OnPerson name = {0} email = {1} id = {2} ", p.Name, p.Email, p.Id);
            }
        }

        private void OnTime(int passedTime)
        {
            Debug.LogErrorFormat("OnTime passedTime = {0}", passedTime);
            base.viewModel.LoginState.Value = string.Format("Start Connecting...{0}\n", passedTime) + base.viewModel.LoginState.Value;
        }
        private void OnStartButton(object param)
        {
            base.Core.UI.Show(UIDefine.LoginAccount);
          //  base.CoreModules.sceneMDL.RunScene(SceneType.Lobby);
        }
        private void OnLoginButton(object param)
        {
            base.viewModel.LoginState.Value = "Start Connecting...\n";

            ServerInfo info = new ServerInfo();
            //info.ip = "47.106.123.211";
            //info.ip = "127.0.0.1"; 172.16.129.128 
            info.ip = "172.16.129.128";
            //info.ip = "192.168.1.100"; 

            info.port = 33000;

            base.CoreModules.netMDL.ConnectServer(info, RomoteType.LOGIN);

        }
        private void OnSendButton(object param)
        {
            if (param is string)
            {
                string str = (string)param;
                if (string.IsNullOrEmpty(str))
                {
                    Debug.LogErrorFormat("OnSendButton str IsNullOrEmpty");
                    return;
                }

                Person p = new Person();
                p.Name = "huangqiaoping_hahaha";
                p.Email = "67449789@qq.com";
                p.Id = 222;

                IBaseMessage msg = ReceiverHelper.PopMessage();
                msg.WriteIn(p, DefineProtobuf.MSG_PERSON);
                CoreModules.netMDL.SendMessage(msg);
                Debug.LogErrorFormat("OnSendButton str = {0}", str);
            }

        }
        public override void OnUpdate(float elapse)
        {
        }

    }
}
