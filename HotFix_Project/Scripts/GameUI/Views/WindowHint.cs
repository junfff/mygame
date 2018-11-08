namespace GameUI
{
    using System;
    using GameBase;
    using UnityEngine;
    using UnityEngine.UI;

    public class WindowHint : BaseView<WindowHintModel>
    {
        private Text info;
        public override void Initialize()
        {
            base.Initialize();
            info = dictBind.FindUI<Text>("info");

            dictBind.AddButton("BackButton", OnBackButton);
            Binder.Add<string>("info", OnInfo);
            
        }

        public override void OnEnter()
        {
            base.OnEnter();
            info.text = base.BindingContext.info.Value;
        }

        private void OnInfo(string oldValue, string newValue)
        {
            info.text = newValue;
        }
   
        public override void Dispose()
        {
            base.Dispose();
            dictBind.RemoveButton("BackButton", OnBackButton);
        }

        private void OnBackButton()
        {
            Debug.Log("OnBackButton！！");
            base.BindingContext.OnBackButton();
        }

    
        
    }
}