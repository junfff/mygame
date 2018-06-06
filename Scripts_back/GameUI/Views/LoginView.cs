using uMVVM.Sources.Infrastructure;
using uMVVM.Sources.ViewModels;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class LoginView : BaseView<LoginViewModel>
    {
        public override void Initialize()
        {
            base.Initialize();
            dictBind.AddButton("StartButton", OnStartButton);

            //Binder.Add<string>("Name", OnNamePropertyValueChanged);
            //Binder.Add<string>("Job", OnJobPropertyValueChanged);
            //Binder.Add<int>("ATK", OnATKPropertyValueChanged);
            //Binder.Add<float>("SuccessRate", OnSuccessRatePropertyValueChanged);
            //Binder.Add<State>("State", OnStatePropertyValueChanged);
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
    }
}