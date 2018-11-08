using System;

namespace GameBase
{
    public class LoginViewModel : ViewModelBase
    {
        public readonly BindableProperty<string> LoginState = new BindableProperty<string>();
        //public readonly BindableProperty<string> Job = new BindableProperty<string>();
        //public readonly BindableProperty<int> ATK = new BindableProperty<int>();
        //public readonly BindableProperty<float> SuccessRate = new BindableProperty<float>();
        //public readonly BindableProperty<State> State = new BindableProperty<State>();

  
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
        public void OnRegisterButton()
        {
            base.messageAggregator.Publish(Define_RegisterButton, true);
        }
        public int Define_StartButton { get { return 1; } }
        public int Define_LoginButton { get { return 2; } }
        public int Define_SendButton { get { return 3; } }
        public int Define_RegisterButton { get { return 4; } }

        public void OnSendButton(string text)
        {
            base.messageAggregator.Publish(Define_SendButton, text);
        }
    }
}
