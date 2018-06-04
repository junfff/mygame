namespace GameBusiness
{
    using GameUtil;
    using Modules;
    using uMVVM.Sources.Infrastructure;
    public class BaseBusiness<T> : IBusiness where T : ViewModelBase
    {
        public int refCount { get; set; }
        protected T viewModel;
        public ICoreUtil Core
        {
            get
            {
                return CoreModules.sceneMDL.curScene.Core;
            }
        }
        public IModulesCollection CoreModules { get; set; }

        public BusinessCollection businessCollection { get; set; }

        public virtual void Dispose()
        {
        }

        public virtual void Initialize()
        {
            viewModel = businessCollection.CreateViewModel<T>();
            viewModel.Initialize();
        }

        public virtual void OnEnd()
        {
        }

        public virtual void OnStart()
        {
        }
    }
}
