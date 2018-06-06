namespace Modules
{
    using GameBase;
    using UnityEngine;

    public class ResourcesModule : BaseModule, IResModule
    {
        public override ModulesType moduleType
        {
            get
            {
                return  ModulesType.RES;
            }
        }
        public T GetRes<T>(string path) where T : Object
        {
            return Object.Instantiate(Resources.Load<T>(path)) as T;
        }


        public bool RecycleRes(Object obj)
        {
            if (null != obj && AssetHelper.IsCloneType(obj))
            {
                UnityEngine.Object.Destroy(obj);
            }
            return false;
        }
    }
}
