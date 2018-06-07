namespace GameRes
{
    using System;
    using UnityEngine;
    public static class AssetHelper
    {
        public static bool IsCloneType(UnityEngine.Object obj)
        {
            Type objType = obj.GetType();
            return objType == typeof(GameObject) || typeof(ScriptableObject).IsAssignableFrom(objType);
        }

    }
}
