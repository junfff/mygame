namespace Modules
{
    using GameBusiness;
    using GameUI;
    using Modules.Scene;
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public class ModulesCollection : IModulesCollection
    {
        public ISceneModules sceneMDL { get; private set; }
        public IResModule resMDL { get; private set; }
        public IBusinessModule busMDL { get; private set; }
        public SceneUIUtil seneUnity { get; private set; }

        private Dictionary<ModulesType, IModules> modulesDict;
        public void Initialize()
        {
            modulesDict = new Dictionary<ModulesType, IModules>();
            resMDL = this.CreateModules<ResourcesModule>();
            sceneMDL = this.CreateModules<SceneModules>();
            busMDL = this.CreateModules<BusinessModules>();
            seneUnity = resMDL.GetRes<SceneUIUtil>(UIDefine.SceneUIUtil);
        }
        public void OnLoad()
        {

        }
        public void OnStart()
        {
            busMDL.OnStart();
        }
        public void OnEnd()
        {
            busMDL.OnEnd();
        }
        public void OnUnLoad()
        {

        }
        public void Dispose()
        {
            resMDL.RecycleRes(seneUnity);

            var enumerator = modulesDict.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                item.Value.Dispose();
            }
        }



        public T CreateModules<T>() where T : IModules
        {
            T module = System.Activator.CreateInstance<T>();
            if (null == module)
            {
                Debug.LogErrorFormat("add module error !!! not find type !!");
                return default(T);
            }
            if (!modulesDict.TryAdd(module.moduleType, module))
            {
                Debug.LogErrorFormat("modulesDict add error !!");
            }

            module.CoreModules = this;
            module.Initialize();

            return module;
        }



        public void OnUpdate(float elapse)
        {
            var enumerator = modulesDict.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                item.Value.OnUpdate(elapse);
            }
        }

        public void OnLateUpdate(float elapse)
        {
            var enumerator = modulesDict.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                item.Value.OnLateUpdate(elapse);
            }
        }
    }
}