namespace GameUI
{
    using System;
    using GameBase;
    using UnityEngine;
    using UnityEngine.UI;

    public class LoginAccount : BaseView<LoginAccountModel>
    {
        private Text LoginState;
        private InputField InputAccount;
        private InputField InputPassed;
        public override void Initialize()
        {
            base.Initialize();
            LoginState = dictBind.FindUI<Text>("LoginState");
            InputAccount = dictBind.FindUI<InputField>("InputAccount");
            InputPassed = dictBind.FindUI<InputField>("InputPassed");

            dictBind.AddButton("LoginButton", OnLoginButton);
            Binder.Add<string>("LoginState", OnLoginState);
        }

        private void OnLoginState(string oldValue, string newValue)
        {
            LoginState.text = newValue;
        }

        public override void Dispose()
        {
            base.Dispose();
            dictBind.RemoveButton("LoginButton", OnLoginButton);
        }



        public void OnLoginButton()
        {
            LoginState.text = "开始登陆账号！！";
            Debug.Log("开始登陆账号！！");
           // base.BindingContext.OnLoginButton();
        }
    }
}