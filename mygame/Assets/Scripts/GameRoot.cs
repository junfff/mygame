using System;
using UnityEngine;

public class GameRoot : MonoSingleton<GameRoot>
{
    //#if UNITY_EDITOR
    //#else 
    //    public bool DEBUG = false;
    //#endif

    public bool DEBUG = false;
    private float elapseTime;
    private IGameAppProxy gameApp;
    protected override void Init()
    {
        if (DEBUG)
        {
            gameApp = new GameAppDebug();
        }
        else
        {
            gameApp = new GameAppILRt();
        }

        gameApp.Init();
    }

    internal void OnUpdateBtn()
    {
        gameApp.DisInit();
        Init();
    }

    protected override void DisInit()
    {
        gameApp.DisInit();
    }
    void Update()
    {
        //print("Update");
        elapseTime = Time.deltaTime;
        gameApp.OnUpdate(elapseTime);

    }

    void LateUpdate()
    {
        //print("LateUpdate");
        gameApp.OnLateUpdate(elapseTime);
    }

    void Start()
    {
    }

}
