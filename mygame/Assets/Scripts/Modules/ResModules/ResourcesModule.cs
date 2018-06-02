namespace Modules
{
    using UnityEngine;

    public class ResourcesModule : BaseModule, IResModule
    {
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
