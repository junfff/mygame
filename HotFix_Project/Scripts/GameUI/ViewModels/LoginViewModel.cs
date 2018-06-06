using GameEvent;
using GameUI;
using uMVVM.Sources.Infrastructure;
using uMVVM.Sources.Models;

namespace uMVVM.Sources.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public readonly BindableProperty<string> Name = new BindableProperty<string>();
        public readonly BindableProperty<string> Job = new BindableProperty<string>();
        public readonly BindableProperty<int> ATK = new BindableProperty<int>();
        public readonly BindableProperty<float> SuccessRate = new BindableProperty<float>();
        public readonly BindableProperty<State> State = new BindableProperty<State>();


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
        //public int Define_StartButton { get { return MessageDefine.Get(OnStartButton); } }
        public int Define_StartButton { get { return 1; } }

    }
}
