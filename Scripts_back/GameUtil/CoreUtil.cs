namespace GameUtil
{
    using Modules;
    using Modules.Scene;
    using System.Collections.Generic;

    public class CoreUtil : ICoreUtil, ICoreModules
    {
        private SceneType m_sceneType;
        private List<IInitialize> listInit;
        private List<IDisposable> listDisp;
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
            var enumerator = listDisp.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                item.Dispose();
            }
        }

        public void Initialize()
        {
            listInit = new List<IInitialize>();
            listDisp = new List<IDisposable>();
            this.UI = this.CreateInstance<SceneUIProxy>();

            var enumerator = listInit.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                item.Initialize();
            }
        }

        private T CreateInstance<T>()
        {
            T t = System.Activator.CreateInstance<T>();

            if (t is IInitialize)
            {
                listInit.Add(t as IInitialize);
            }
            if (t is IDisposable)
            {
                listDisp.Add(t as IDisposable);
            }
            if (t is ICore)
            {
                (t as ICore).Core = this;
            }
            if (t is ICoreModules)
            {
                (t as ICoreModules).CoreModules = this.CoreModules;
            }
            return t;
        }
    }
}