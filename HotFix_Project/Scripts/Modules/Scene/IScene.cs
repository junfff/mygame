namespace Modules.Scene
{
    using GameBusiness;
    using GameUtil;
    using System;
    using uMVVM.Sources.Infrastructure;

    public interface IScene : IUpdate, ILateUpdate, IInitialize, IDisposable, ICoreModules
    {
        BusinessCollection businessCollection { get; }
        CoreUtil Core { get; }
        SceneType sceneType { get; }
        SceneStep sceneStep { get; set; }
        Action<IScene> DoneCallBack { set; }

        void OnLoad();
        void OnUnLoad();
        void OnStart();
        void OnEnd();
        void OnNextStep();
        bool AddBusiness<T>() where T : IBusiness;
        bool RemoveBusiness<T>() where T : IBusiness;
        T CreateViewModel<T>() where T : ViewModelBase;
        T GetViewModel<T>() where T : ViewModelBase;
    }
}