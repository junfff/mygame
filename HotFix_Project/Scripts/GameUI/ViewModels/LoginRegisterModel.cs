using System;

namespace GameBase
{
    public class LoginRegisterModel : ViewModelBase
    {
        public readonly BindableProperty<string> accountId = new BindableProperty<string>();
        public readonly BindableProperty<string> pwd = new BindableProperty<string>();
        public readonly BindableProperty<string> name = new BindableProperty<string>();
        public readonly BindableProperty<string> mobilephone = new BindableProperty<string>();
        public readonly BindableProperty<string> email = new BindableProperty<string>();
        public readonly BindableProperty<int> sex = new BindableProperty<int>();

  
        public void OnBackButton()
        {
            base.messageAggregator.Publish(Define_BackButton, true);
        }
        public void OnRegisterButton()
        {
            base.messageAggregator.Publish(Define_RegisterButton, true);
        }
        public int Define_RegisterButton { get { return 1; } }
        public int Define_BackButton { get { return 2; } }

    }
}
