using System;

namespace GameBase
{
    public class LoginAccountModel : ViewModelBase
    {
        public readonly BindableProperty<string> LoginState = new BindableProperty<string>();
        public readonly BindableProperty<string> account_text = new BindableProperty<string>();
        public readonly BindableProperty<string> passed_text = new BindableProperty<string>();


        public override void OnStartReveal()
        {
            base.OnStartReveal();
        }
        public override void OnStartHide()
        {
            base.OnStartHide();
        }

        public void OnStartButton()
        {
            base.messageAggregator.Publish(Define_BackBtn, true);
        }
        public void OnLoginButton()
        {
            base.messageAggregator.Publish(Define_LoginButton, true);
        }
        public int Define_BackBtn { get { return 1; } }
        public int Define_LoginButton { get { return 2; } }
        public int Define_SendButton { get { return 3; } }

        public void OnSendButton(string text)
        {
            base.messageAggregator.Publish(Define_SendButton, text);
        }

        internal void OnBackButton()
        {
            base.messageAggregator.Publish(Define_BackBtn, true);
        }
    }
}
