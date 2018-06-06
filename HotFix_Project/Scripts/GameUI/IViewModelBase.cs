namespace GameUI
{
    using GameEvent;
    using System;

    public interface IViewModelBase : IInitialize, IDisposable
    {
        MessageAggregator messageAggregator { get; }
        void OnStartReveal();
        void OnFinishReveal();
        void OnStartHide();
        void OnFinishHide();
    }
}