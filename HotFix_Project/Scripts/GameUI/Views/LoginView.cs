namespace GameUI
{
    using System;
    using GameBase;
    using UnityEngine.UI;

    public class LoginView : BaseView<LoginViewModel>
    {
        private Text LoginState;
        public override void Initialize()
        {
            base.Initialize();
            LoginState = dictBind.FindUI<Text>("LoginState");
            dictBind.AddButton("StartButton", OnStartButton);
            dictBind.AddButton("LoginButton", OnLoginButton);

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
        }
        public void OnStartButton()
        {
            base.BindingContext.OnStartButton();
        }
        public void OnLoginButton()
        {
            base.BindingContext.OnLoginButton();
        }
    }
}