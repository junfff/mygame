namespace GameUtil
{
    using Modules;
    using Modules.Scene;
    using System.Collections.Generic;

    public class CoreUtil : ICoreUtil, ICoreModules
    {
        private SceneType m_sceneType;
        private List<BaseProxy> listProxy;
        public CoreUtil(SceneType sceneType)
        {
            this.m_sceneType = sceneType;
        }

        public SceneType sceneType
        {
            get
            {
                return m_sceneType;
            }
        }
        public IModulesCollection CoreModules { get; set; }
        public IUIUtil UI { get; private set; }


        public void Dispose()
        {
            var enumerator = listProxy.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                item.Dispose();
            }
        }

        public void Initialize()
        {
            listProxy = new List<BaseProxy>();
            this.UI = this.CreateInstance<SceneUIProxy>();

            var enumerator = listProxy.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                item.Initialize();
            }
        }

        private T CreateInstance<T>() where T : BaseProxy
        {
            T t = System.Activator.CreateInstance<T>();

            listProxy.Add(t);
            t.Core = this;
            t.CoreModules = this.CoreModules;
            return t;
        }
    }
}