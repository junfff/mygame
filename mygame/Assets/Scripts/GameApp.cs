using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameApp : MonoSingleton<GameApp>
{

    private ModulesMgr modulesMgr;

    protected override void Init()
    {
        print("GameApp Init");
        modulesMgr = new ModulesMgr();

        modulesMgr.Initialize();

    }

    protected override void DisInit()
    {
        print("GameApp DisInit");
        modulesMgr.Dispose();
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

    //void Update()
    //{
    //    print("Update");
    //}

    //void LateUpdate()
    //{
    //    print("LateUpdate");
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
