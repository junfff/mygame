namespace Modules
{
    public class BaseModule : IModules
    {
        public virtual ModulesType moduleType
        {
            get
            {
                return ModulesType.NONE;
            }
        }

        public IModulesCollection CoreModules { get; set; }

        public virtual void Dispose()
        {

        }

        public virtual void Initialize()
        {

        }

        public virtual void OnLateUpdate(float elapse)
        {

        }

        public virtual void OnUpdate(float elapse)
        {

        }
    }
}
