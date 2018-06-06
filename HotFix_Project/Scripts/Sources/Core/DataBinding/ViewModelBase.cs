namespace GameBase
{
    using GameEvent;
    using GameUI;

    public class ViewModelBase : IViewModelBase
    {
        public MessageAggregator messageAggregator { get; private set; }
        public ViewModelBase ParentViewModel { get; set; }
        public bool IsRevealed { get; private set; }
        public bool IsRevealInProgress { get; private set; }
        public bool IsHideInProgress { get; private set; }

        public virtual void Initialize()
        {
            messageAggregator = new MessageAggregator();
        }

        public virtual void Dispose()
        {
            messageAggregator.Dispose();
        }
        public virtual void OnStartReveal()
        {
            IsRevealInProgress = true;
        }

        public virtual void OnFinishReveal()
        {
            IsRevealInProgress = false;
            IsRevealed = true;
        }

 

        public virtual void OnStartHide()
        {
            IsHideInProgress = true;

        }

        public virtual void OnFinishHide()
        {
            IsHideInProgress = false;
            IsRevealed = false;
        }


    }
}
