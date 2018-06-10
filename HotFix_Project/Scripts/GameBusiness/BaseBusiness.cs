namespace GameBusiness
{
    using GameBase;
    using GameEvent;
    using GameTimer;
    using GameUtil;
    public class BaseBusiness<T> : IBusiness where T : ViewModelBase
    {
        protected ITimerModule timerHandler;
        public int refCount { get; set; }
        protected T viewModel;
        public ICoreUtil Core
        {
            get
            {
                return CoreModules.sceneMDL.curScene.Core;
            }
        }

        protected void Subscribe(int id, MessageHandler handler)
        {
            viewModel.messageAggregator.Subscribe(id, handler);
        }
        protected void UnSubscribe(int id, MessageHandler handler)
        {
            viewModel.messageAggregator.UnSubscribe(id, handler);
        }
        public IModulesCollection CoreModules { get; set; }

        public BusinessCollection businessCollection { get; set; }

        public virtual void Dispose()
        {
        }

        public virtual void Initialize()
        {
            timerHandler = new TimerHandler(CoreModules);
            viewModel = businessCollection.CreateViewModel<T>();
            viewModel.Initialize();
        }

        public virtual void OnEnd()
        {
            timerHandler.Clear();
        }

        public virtual void OnStart()
        {
        }

        public virtual void OnUpdate(float elapse)
        {
           
        }

        public virtual void OnLateUpdate(float elapse)
        {
           
        }











    }
}
