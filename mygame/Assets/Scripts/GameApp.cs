using Modules;
using UnityEngine;
public class GameApp : MonoSingleton<GameApp>
{
    //在游戏启动时，会自动调用添加了该属性的方法。
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        Debug.Log("Game loaded and is running");
    }
    private ModulesCollection modulesMgr;
    private float elapseTime;
    protected override void Init()
    {
        print("GameApp Init");
        modulesMgr = new ModulesCollection();
        modulesMgr.Initialize();
    }

    protected override void DisInit()
    {
        print("GameApp DisInit");
        modulesMgr.Dispose();
    }

    void Update()
    {
        //print("Update");
        elapseTime = Time.deltaTime;

        modulesMgr.OnUpdate(elapseTime);
    }

    void LateUpdate()
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
