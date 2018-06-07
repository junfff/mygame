namespace GameBase
{
    using GameBusiness;
    using GameNet;
    using GameRes;
    using GameScene;
    using GameUI;
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public class ModulesCollection : IModulesCollection
    {
        public ISceneModules sceneMDL { get; private set; }
        public IResModule resMDL { get; private set; }
        public IBusinessModule busMDL { get; private set; }
        public INetModule netMDL { get; private set; }
        
        public SceneUIUtil seneUnity { get; private set; }

        private Dictionary<ModulesType, IModules> modulesDict;
        public void Initialize()
        {
            modulesDict = new Dictionary<ModulesType, IModules>();
            resMDL = this.CreateModules<ResourcesModule>();
            sceneMDL = this.CreateModules<SceneModule>();
            busMDL = this.CreateModules<BusinessModule>();
            netMDL = this.CreateModules<NetModule>();
            seneUnity = resMDL.GetRes<SceneUIUtil>(UIDefine.SceneUIUtil);
            //data
            //
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
            T module = Activator.CreateInstance<T>();
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