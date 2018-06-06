namespace Modules
{
    using GameBusiness;
    using uMVVM.Sources.Infrastructure;

    public interface IBusinessCollection
    {
        bool AddBusiness<T>() where T : IBusiness;
        bool RemoveBusiness<T>() where T : IBusiness;
        void OnStart();
        void OnEnd();
        T CreateViewModel<T>() where T : ViewModelBase;
        T GetViewModel<T>() where T : ViewModelBase;
    }
}
