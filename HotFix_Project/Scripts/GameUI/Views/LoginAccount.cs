﻿namespace GameUI
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
            dictBind.AddButton("BackButton", OnBackButton);
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
            dictBind.RemoveButton("BackButton", OnBackButton);
        }



        private void OnBackButton()
        {
            Debug.Log("OnBackButton！！");
            base.BindingContext.OnBackButton();
        }
        private void OnLoginButton()
        {
            LoginState.text = "开始登陆账号！！";
            base.BindingContext.account_text.Value = InputAccount.text;
            base.BindingContext.passed_text.Value = InputPassed.text;
            base.BindingContext.OnLoginButton();
        }
    }
}