namespace GameBusiness
{
    using GameBase;
 
    public class BusinessModule : BaseModule, IBusinessModule
    {
        public override ModulesType moduleType
        {
            get
            {
                return ModulesType.BUSINESS;
            }
        }
        private BusinessCollection collection;
        public override void Initialize()
        {
            base.Initialize();
            collection = new BusinessCollection();
            collection.CoreModules = CoreModules;
            collection.Initialize();
        }
        public override void Dispose()
        {
            base.Dispose();
            collection.Dispose();
        }
        public override void OnUpdate(float elapse)
        {
            base.OnUpdate(elapse);
            collection.OnUpdate(elapse);
        }
        public override void OnLateUpdate(float elapse)
        {
            base.OnLateUpdate(elapse);
            collection.OnLateUpdate(elapse);
        }

        public void OnStart()
        {
            collection.OnStart();
        }
        public void OnEnd()
        {
            collection.OnEnd();
        }

        public bool AddBusiness<T>() where T : IBusiness
        {
            return collection.AddBusiness<T>();
        }
        public bool RemoveBusiness<T>() where T : IBusiness
        {
            return collection.RemoveBusiness<T>();
        }


    }
}
