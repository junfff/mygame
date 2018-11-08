namespace GameBusiness
{
    using GameBase;
    using GameEvent;
    using UnityEngine;
    public class WindowHintBusiness : BaseBusiness<WindowHintModel>, IUpdate
    {
        public override void OnStart()
        {
            base.OnStart();
            base.Subscribe(base.viewModel.Define_BackButton, OnBackBtn);
            
            base.businessCollection.CoreModules.eventMDL.Subscribe(DefineEvent.EVENT_WINDOWHINT_INFO,OnInfo);
        }
        public override void OnEnd()
        {
            base.OnEnd();
            base.UnSubscribe(base.viewModel.Define_BackButton, OnBackBtn);
            
            base.businessCollection.CoreModules.eventMDL.UnSubscribe(DefineEvent.EVENT_WINDOWHINT_INFO,OnInfo);
        }

        private void OnInfo(object param)
        {
            if (param is string)
            {
                Debug.LogErrorFormat("oninfo param = {0}",(string)param);
                base.viewModel.info.Value = (string)param;
            }
        }


        private void OnBackBtn(object param)
        {
            base.Core.UI.BackPage();
        }
 
    
        public override void OnUpdate(float elapse)
        {
        }

    }
}
