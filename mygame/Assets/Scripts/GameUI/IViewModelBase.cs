namespace GameUI
{
    using GameEvent;

    public interface IViewModelBase : IInitialize, IDisposable
    {
        MessageAggregator messageAggregator { get; }
        void OnStartReveal();
        void OnFinishReveal();
        void OnStartHide();
        void OnFinishHide();
    }
}