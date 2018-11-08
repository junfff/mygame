using System;

namespace GameBase
{
    public class WindowHintModel : ViewModelBase
    {
        public readonly BindableProperty<string> info = new BindableProperty<string>();
  
        public void OnBackButton()
        {
            base.messageAggregator.Publish(Define_BackButton, true);
        }
        public int Define_BackButton { get { return 2; } }

    }
}
