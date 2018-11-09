using System;

namespace GameBase
{
    public class HeartBeatModel : ViewModelBase
    {
        public readonly BindableProperty<int> ping = new BindableProperty<int>();

  
        public void OnBackButton()
        {
            base.messageAggregator.Publish(Define_BackButton, true);
        }
        public int Define_BackButton { get { return 2; } }

    }
}
