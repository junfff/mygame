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
    public class LoginRegisterBusiness : BaseBusiness<LoginRegisterModel>, IUpdate
    {
        public override void OnStart()
        {
            base.OnStart();
            base.Subscribe(base.viewModel.Define_RegisterButton, OnRegisterButton);
            base.Subscribe(base.viewModel.Define_BackButton, OnBackBtn);
        }
        public override void OnEnd()
        {
            base.OnEnd();
            base.UnSubscribe(base.viewModel.Define_RegisterButton, OnRegisterButton);
            base.UnSubscribe(base.viewModel.Define_BackButton, OnBackBtn);
        }



        private void OnBackBtn(object param)
        {
            base.Core.UI.BackPage();
        }
        private void OnRegisterButton(object param)
        {
            Debug.LogErrorFormat("点击了注册按钮 ！！！account = {0}  passed = {1}", base.viewModel.accountId.Value, base.viewModel.name.Value);

            base.Core.UI.Show(UIDefine.WindowHint);
            base.businessCollection.CoreModules.eventMDL.Publish(DefineEvent.EVENT_WINDOWHINT_INFO, "注册失败了！！！");
//            Person p = new Person();
//            p.Name = "huangqiaoping_hahaha";
//            p.Email = "67449789@qq.com";
//            p.Id = 222;
//
//            IBaseMessage msg = ReceiverHelper.PopMessage();
//            msg.WriteIn(p, DefineProtobuf.MSG_PERSON);
//            CoreModules.netMDL.SendMessage(msg);

        }
    
        public override void OnUpdate(float elapse)
        {
        }

    }
}
