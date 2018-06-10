using System;
namespace GameBase
{
    public interface IModules : IInitialize, IDisposable, IUpdate, ILateUpdate,ICoreModules
    {
        ModulesType moduleType { get; }
        void OnLoad();
        void OnUnLoad();
        void OnStart();
        void OnEnd();
    }
}