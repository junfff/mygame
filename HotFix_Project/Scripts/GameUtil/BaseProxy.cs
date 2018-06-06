namespace GameUtil
{
    using GameBase;
    using Modules;
    using System;
    public class BaseProxy : IDisposable, IInitialize, ICore, ICoreModules
    {
        public ICoreUtil Core { get; set; }
        public IModulesCollection CoreModules { get; set; }

        public virtual void Dispose()
        {

        }

        public virtual void Initialize()
        {

        }
    }
}
