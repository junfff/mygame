using ProtobufMsg;

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
            base.Subscribe(base.viewModel.Define_RegisterButton,OnRegisterButton);

            //base.timerHandler.AddTimer(1000, OnTime);

            base.CoreModules.eventMDL.Subscribe(DefineProtobuf.MSG_PERSON, OnPerson);
        }
        public override void OnEnd()
        {
            base.OnEnd();
            base.UnSubscribe(base.viewModel.Define_StartButton, OnStartButton);
            base.UnSubscribe(base.viewModel.Define_LoginButton, OnLoginButton);
            base.UnSubscribe(base.viewModel.Define_SendButton, OnSendButton);
            base.UnSubscribe(base.viewModel.Define_RegisterButton,OnRegisterButton);
            
            base.CoreModules.eventMDL.UnSubscribe(DefineProtobuf.MSG_PERSON, OnPerson);
        }

        private void OnPerson(object param)
        {
            if (param is MsgPerson)
            {
                MsgPerson p = param as MsgPerson;
                Debug.LogErrorFormat(">>>> LoginBusiness OnPerson name = {0} email = {1} id = {2} ", p.Name, p.Email, p.Id);
            }
        }

        private void OnTime(int passedTime)
        {
            Debug.LogErrorFormat("OnTime passedTime = {0}", passedTime);
            base.viewModel.LoginState.Value = string.Format("Start Connecting...{0}\n", passedTime) + base.viewModel.LoginState.Value;
        }

        private void OnRegisterButton(object param)
        {
            base.Core.UI.Show(UIDefine.LoginRegister);
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
            info.ip = "172.16.129.131";
            //info.ip = "127.0.0.1"; 172.16.129.128  172.16.252.134 172.16.252.134
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

                MsgPerson p = new MsgPerson();
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
