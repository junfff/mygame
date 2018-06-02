using uMVVM.Sources.Infrastructure;
using uMVVM.Sources.ViewModels;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class LoginView : BaseView<SetupViewModel>
    {
        public LoginView()
        {
            base.ViewType = UIDefine.Login;
            BindingContext = new SetupViewModel();
        }
        public override void Initialize()
        {
            base.Initialize();
            base.AddButton("StartButton", OnStartButton);
        }
        public override void Dispose()
        {
            base.Dispose();
            base.RemoveButton("StartButton", OnStartButton);
        }
        public void OnStartButton()
        {
            base.Core.UI.Show(UIDefine.MainView);
            base.Core.UI.Hide(UIDefine.LoginView);
        }
    }
}