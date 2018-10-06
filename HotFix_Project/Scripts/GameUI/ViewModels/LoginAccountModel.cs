using System;

namespace GameBase
{
    public class LoginAccountModel : ViewModelBase
    {
        public readonly BindableProperty<string> LoginState = new BindableProperty<string>();


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
            base.messageAggregator.Publish(Define_StartButton, true);
        }
        public void OnLoginButton()
        {
            base.messageAggregator.Publish(Define_LoginButton, true);
        }
        public int Define_StartButton { get { return 1; } }
        public int Define_LoginButton { get { return 2; } }
        public int Define_SendButton { get { return 3; } }

        public void OnSendButton(string text)
        {
            base.messageAggregator.Publish(Define_SendButton, text);
        }
    }
}
