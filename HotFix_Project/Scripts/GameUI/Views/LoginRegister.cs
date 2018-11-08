namespace GameUI
{
    using System;
    using GameBase;
    using UnityEngine;
    using UnityEngine.UI;

    public class LoginRegister : BaseView<LoginRegisterModel>
    {
        private InputField InputAccount;
        private InputField InputPassed;
        private InputField InputName;
        private InputField InputMobilephone;
        private InputField InputEmail;
        private Toggle Toggle_man;
        private Toggle Toggle_woman;
        public override void Initialize()
        {
            base.Initialize();
            InputAccount = dictBind.FindUI<InputField>("InputAccount");
            InputPassed = dictBind.FindUI<InputField>("InputPassed");
            InputName = dictBind.FindUI<InputField>("InputName");
            InputMobilephone = dictBind.FindUI<InputField>("InputMobilephone");
            InputEmail = dictBind.FindUI<InputField>("InputEmail");
            Toggle_man = dictBind.FindUI<Toggle>("Toggle_man");
            Toggle_woman = dictBind.FindUI<Toggle>("Toggle_woman");

            dictBind.AddButton("BackButton", OnBackButton);
            dictBind.AddButton("RegisterButton", OnRegisterButton);

        }

   
        public override void Dispose()
        {
            base.Dispose();
            dictBind.RemoveButton("BackButton", OnBackButton);
            dictBind.RemoveButton("RegisterButton", OnRegisterButton);
        }

        private void OnBackButton()
        {
            Debug.Log("OnBackButton！！");
            base.BindingContext.OnBackButton();
        }

        public void OnRegisterButton()
        {
            base.BindingContext.accountId.Value = InputAccount.text;
            base.BindingContext.pwd.Value = InputPassed.text;
            base.BindingContext.name.Value = InputName.text;
            base.BindingContext.mobilephone.Value = InputMobilephone.text;
            base.BindingContext.email.Value = InputEmail.text;
            base.BindingContext.sex.Value = Toggle_man.isOn ? 1 : 0;
            base.BindingContext.OnRegisterButton();
        }
        
    }
}