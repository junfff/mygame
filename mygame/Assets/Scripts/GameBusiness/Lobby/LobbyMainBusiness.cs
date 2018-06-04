namespace GameBusiness
{
    using GameUI;
    using uMVVM.Sources.ViewModels;

    public class LobbyMainBusiness : BaseBusiness<LobbyMainViewModel>
    {
        public override void OnStart()
        {
            base.OnStart();
            base.Core.UI.Show(UIDefine.LobbyMainView);

        }
        public override void OnEnd()
        {
            base.OnEnd();
        }
    }
}
