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
    public class LoginAccountBusiness : BaseBusiness<LoginAccountModel>, IUpdate
    {
        public override void OnStart()
        {
            base.OnStart();
            base.Subscribe(base.viewModel.Define_LoginButton, OnLoginButton);
            base.Subscribe(base.viewModel.Define_BackBtn, OnBackBtn);
            base.CoreModules.eventMDL.Subscribe(DefineEvent.EVENT_SOCKET_STATUS, OnSocketStatus);
        }
        public override void OnEnd()
        {
            base.OnEnd();
            base.UnSubscribe(base.viewModel.Define_LoginButton, OnLoginButton);
            base.UnSubscribe(base.viewModel.Define_BackBtn, OnBackBtn);
            base.CoreModules.eventMDL.UnSubscribe(DefineEvent.EVENT_SOCKET_STATUS, OnSocketStatus);
        }

        private void OnSocketStatus(object param)
        {
            if (param is SocketConnectState)
            {
                SocketConnectState p = param as SocketConnectState;
                if (p.socketState == SocketState.CONNECTED)
                {
                    Debug.LogErrorFormat("开始登录 ！！！socketState = {0}", p.socketState);
                    Debug.LogErrorFormat("开始登录 ！！！account = {0}  passed = {1}", base.viewModel.account_text.Value, base.viewModel.passed_text.Value);
                }

            }
        }

        private void OnBackBtn(object param)
        {
            base.Core.UI.BackPage();
        }
        private void OnLoginButton(object param)
        {
            Debug.LogErrorFormat("点击了登陆按钮 ！！！account = {0}  passed = {1}", base.viewModel.account_text.Value, base.viewModel.passed_text.Value);

            base.viewModel.LoginState.Value = "Start Connecting...\n";

            ServerInfo info = new ServerInfo();
            info.ip = "47.106.123.211";
            //info.ip = "127.0.0.1"; 172.16.129.128 
            //info.ip = "172.16.129.128";
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
