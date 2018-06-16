namespace GameBusiness
{
    using GameBase;
    using GameNet;
    using GameScene;
    using GameUI;
    using Google.Protobuf;
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
            if (param is string)
            {
                string str = (string)param;
                if (string.IsNullOrEmpty(str))
                {
                    Debug.LogErrorFormat("OnSendButton str IsNullOrEmpty");
                    return;
                }


                Person p = new Person();
                p.Name = "liujunfeng";
                p.Email = "67449789@qq.com";
                p.Id = 333;

                //序列化操作
                MemoryStream stream = new MemoryStream();
                p.WriteTo(stream);
                byte[] buffer = stream.ToArray();

               //反序列化操作
               Person p2 = new Person();
                p2.MergeFrom(buffer);

                string bufferstr = System.Text.Encoding.Default.GetString(buffer);
                Debug.LogErrorFormat("name = {0} email = {1} id = {2} bufferstr = {3} buffer length = {4}", p2.Name, p2.Email, p2.Id, bufferstr, buffer.Length);

                return;






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
