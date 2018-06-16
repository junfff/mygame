namespace GameRes
{
    using GameBase;
    using UnityEngine;

    public class ResourcesModule : BaseModule, IResModule
    {
        public override ModulesType moduleType
        {
            get
            {
                return ModulesType.RES;
            }
        }
        public T GetRes<T>(string path) where T : Object
        {
            return Object.Instantiate(Resources.Load<T>(path)) as T;
        }


        public bool RecycleRes(Object obj)
        {
            if (null != obj && obj.name.Contains("Clone"))
            {
                Debug.LogWarningFormat("Destroy obj name = {0}", obj.name);
                UnityEngine.Object.Destroy(obj);
                return true;
            }
            Debug.LogWarningFormat("RecycleRes false Destroy obj name = {0}", obj.name);
            return false;
        }
    }
}
