namespace GameBase
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

        public virtual void OnEnd()
        {
          
        }

        public virtual void OnLateUpdate(float elapse)
        {

        }

        public virtual void OnLoad()
        {
         
        }

        public virtual void OnStart()
        {
           
        }

        public virtual void OnUnLoad()
        {
           
        }

        public virtual void OnUpdate(float elapse)
        {

        }
    }
}
