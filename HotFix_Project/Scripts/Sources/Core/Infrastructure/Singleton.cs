using System;

namespace Assets.Sources.Core.Infrastructure
{
    /// <summary>
    ///     继承自该类，实现 Unity MonoBehaviour 单例模式.
    /// </summary>
    public class Singleton<T> where T : Singleton<T>, new()
    {
        private static T _instance;

        static Singleton()
        {
            Singleton<T>._instance = default(T);
        }
        public virtual void Init()
        {

        }
        public virtual void Dispose()
        {
            Singleton<T>._instance = default(T);
        }
        public static T Instance
        {
            get
            {
                return GetInstance();
            }
        }

        private static T GetInstance()
        {
            if (null == Singleton<T>._instance)
            {
                Singleton<T>._instance = Activator.CreateInstance<T>();
                Singleton<T>._instance.Init();
            }
            return Singleton<T>._instance;

        }




    }
}
