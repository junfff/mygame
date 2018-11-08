namespace GameUI
{
    using System;
    using GameBase;
    using UnityEngine;
    using UnityEngine.UI;

    public class LoginView : BaseView<LoginViewModel>
    {
        private Text LoginState;
        private InputField InputField;
        public override void Initialize()
        {
            base.Initialize();
            LoginState = dictBind.FindUI<Text>("LoginState");
            InputField = dictBind.FindUI<InputField>("InputField");

            dictBind.AddButton("StartButton", OnStartButton);
            dictBind.AddButton("LoginButton", OnLoginButton);
            dictBind.AddButton("SendButton", OnSendButton);
            dictBind.AddButton("RegisterButton", OnRegisterButton);

            Binder.Add<string>("LoginState", OnLoginState);

            //Binder.Add<string>("Job", OnJobPropertyValueChanged);
            //Binder.Add<int>("ATK", OnATKPropertyValueChanged);
            //Binder.Add<float>("SuccessRate", OnSuccessRatePropertyValueChanged);
            //Binder.Add<State>("State", OnStatePropertyValueChanged);
        }

        private void OnLoginState(string oldValue, string newValue)
        {
            LoginState.text = newValue;
        }

        public override void Dispose()
        {
            base.Dispose();
            dictBind.RemoveButton("StartButton", OnStartButton);
            dictBind.RemoveButton("LoginButton", OnLoginButton);
            dictBind.RemoveButton("SendButton", OnSendButton);
            dictBind.RemoveButton("RegisterButton", OnSendButton);
        }

        private void OnSendButton()
        {
            base.BindingContext.OnSendButton(InputField.text);
            InputField.text = string.Empty;  
        }

        public void OnStartButton()
        {
            base.BindingContext.OnStartButton();
        }
        public void OnLoginButton()
        {
            base.BindingContext.OnLoginButton();
        }

        public void OnRegisterButton()
        {
            base.BindingContext.OnRegisterButton();
        }
        
    }
}