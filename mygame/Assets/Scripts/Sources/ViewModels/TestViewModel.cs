using uMVVM.Sources.Infrastructure;

namespace Assets.Sources.ViewModels
{
    public class TestViewModel:ViewModelBase
    {
        public readonly BindableProperty<string> Color=new BindableProperty<string>();

        public TestViewModel()
        {
            //MessageAggregator<object>.Instance.Subscribe("Toggle",ToggleHandler);//TODO
        }

        //private void ToggleHandler(object sender, MessageArgs<object> args)
        //{
        //    Color.Value = (string) args.Item;
        //}
    }
}
