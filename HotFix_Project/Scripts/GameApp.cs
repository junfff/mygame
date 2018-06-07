namespace GameBase
{
    using System;
    using UnityEngine;
    public class GameApp : IInitialize, IDisposable, IUpdate, ILateUpdate
    {
        //在游戏启动时，会自动调用添加了该属性的方法。
        [RuntimeInitializeOnLoadMethod]
        static void OnRuntimeMethodLoad()
        {
            Debug.Log("Game loaded and is running");
        }
        private ModulesCollection modulesMgr;
        public void Initialize()
        {
            Debug.LogFormat("GameApp Init 123");
            modulesMgr = new ModulesCollection();
            modulesMgr.Initialize();
            modulesMgr.OnLoad();
            modulesMgr.OnStart();
        }

        public void Dispose()
        {
            Debug.LogFormat("GameApp DisInit");
            modulesMgr.OnUnLoad();
            modulesMgr.OnEnd();
            modulesMgr.Dispose();
        }

        public void OnUpdate(float elapseTime)
        {
            //print("Update");

            modulesMgr.OnUpdate(elapseTime);
        }

        public void OnLateUpdate(float elapseTime)
        {
            //print("LateUpdate");

            modulesMgr.OnLateUpdate(elapseTime);
        }







        //void Awake()
        //{
        //    print("Awake");

        //}

        //void OnEnable()
        //{
        //    print("OnEnable");
        //}

        //void Start()
        //{
        //    print("Start");
        //}

        //void FixedUpdate()
        //{
        //    print("FixedUpdate");
        //}



        //void OnGUI()
        //{
        //    print("OnGUI");
        //}


        //// *************************************
        //void OnDisable()
        //{
        //    print("OnDisable");
        //}

        //void OnDestroy()
        //{
        //    print("OnDestroy");
        //}

        //// *************************************
        //void Reset()
        //{
        //    print("OnReset");
        //}


    }
}