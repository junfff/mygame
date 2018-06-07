using ILRuntime.CLR.TypeSystem;
using System.Collections;
using System.IO;
using UnityEngine;
public class GameAppILRt : IGameAppProxy
{
    private object GameApp_obj;
    private IType GameApp_type;
    public void DisInit()
    {
        GameApp_obj_Invoke("Dispose");
    }

    public void Init()
    {
        GameRoot.instance.StartCoroutine(LoadHotFixAssembly());
    }

    public void OnLateUpdate(float elapseTime)
    {
        GameApp_obj_Invoke("OnLateUpdate", elapseTime);
    }

    public void OnUpdate(float elapseTime)
    {
        GameApp_obj_Invoke("OnUpdate", elapseTime);
    }


    //*******************************





    //AppDomain是ILRuntime的入口，最好是在一个单例类中保存，整个游戏全局就一个，这里为了示例方便，每个例子里面都单独做了一个
    //大家在正式项目中请全局只创建一个AppDomain
    ILRuntime.Runtime.Enviorment.AppDomain appdomain;

    IEnumerator LoadHotFixAssembly()
    {
        //首先实例化ILRuntime的AppDomain，AppDomain是一个应用程序域，每个AppDomain都是一个独立的沙盒
        appdomain = new ILRuntime.Runtime.Enviorment.AppDomain();
        //正常项目中应该是自行从其他地方下载dll，或者打包在AssetBundle中读取，平时开发以及为了演示方便直接从StreammingAssets中读取，
        //正式发布的时候需要大家自行从其他地方读取dll

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //这个DLL文件是直接编译HotFix_Project.sln生成的，已经在项目中设置好输出目录为StreamingAssets，在VS里直接编译即可生成到对应目录，无需手动拷贝
#if UNITY_ANDROID
        WWW www = new WWW(Application.streamingAssetsPath + "/HotFix_Project.dll");
#else
        //string path = "file:///" + Application.streamingAssetsPath + "/HotFix_Project.dll";
        string path = "file:///" + Application.dataPath + "/StreamingAssets/HotFix_Project.dll";
        WWW www = new WWW(path);
#endif
        while (!www.isDone)
            yield return null;
        if (!string.IsNullOrEmpty(www.error))
            Debug.LogError(www.error);
        byte[] dll = www.bytes;
        www.Dispose();

        //PDB文件是调试数据库，如需要在日志中显示报错的行号，则必须提供PDB文件，不过由于会额外耗用内存，正式发布时请将PDB去掉，下面LoadAssembly的时候pdb传null即可
#if UNITY_ANDROID
        www = new WWW(Application.streamingAssetsPath + "/HotFix_Project.pdb");
#else
        www = new WWW("file:///" + Application.streamingAssetsPath + "/HotFix_Project.pdb");
        //www = new WWW("file:///" + Application.dataPath + "/Plugins/x86_64/HotFix_Project.pdb");
#endif
        while (!www.isDone)
            yield return null;
        if (!string.IsNullOrEmpty(www.error))
            Debug.LogError(www.error);
        byte[] pdb = www.bytes;
        www.Dispose();

        using (MemoryStream fs = new MemoryStream(dll))
        {
            using (MemoryStream p = new MemoryStream(pdb))
            {
                appdomain.LoadAssembly(fs, p, new Mono.Cecil.Pdb.PdbReaderProvider());
            }
        }

        InitializeILRuntime();
        OnHotFixLoaded();
    }

    void InitializeILRuntime()
    {
        //这里做一些ILRuntime的注册，HelloWorld示例暂时没有需要注册的
        //appdomain.RegisterCrossBindingAdaptor(new IDisposableAdapter());
        appdomain.RegisterCrossBindingAdaptor(new CoroutineAdapter());

        appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction>((action) =>
        {
            return new UnityEngine.Events.UnityAction(() =>
            {
                ((System.Action)action)();
            });
        });

        appdomain.DelegateManager.RegisterDelegateConvertor<System.Action>((action) =>
        {
            return new System.Action(() =>
            {
                ((System.Action)action)();
            });
        });

        ILRuntime.Runtime.Generated.CLRBindings.Initialize(appdomain);
    }

    void OnHotFixLoaded()
    {
        //HelloWorld，第一次方法调用
        //appdomain.Invoke("HotFix_Project.InstanceClass", "StaticFunTest", null, null);
        //appdomain.Invoke("HotFix_Project.InstanceClass", "StaticFunTest2", null, 55);

        //Debug.Log("实例化热更里的类");
        //object obj2 = appdomain.Instantiate("HotFix_Project.InstanceClass", new object[] { 233 });

        GameApp_type = appdomain.LoadedTypes["GameBase.GameApp"];
        GameApp_obj = ((ILType)GameApp_type).Instantiate();

        GameApp_obj_Invoke("Initialize");




        //Debug.Log("热更DLL中的类型我们均需要通过AppDomain取得");
        //var it = appdomain.LoadedTypes["GameBase.GameApp"];
        //Debug.Log("LoadedTypes返回的是IType类型，但是我们需要获得对应的System.Type才能继续使用反射接口");
        //var type = it.ReflectionType;
        //Debug.Log("取得Type之后就可以按照我们熟悉的方式来反射调用了");
        //var ctor = type.GetConstructor(new System.Type[0]);
        //var obj = ctor.Invoke(null);
        //Debug.Log("打印一下结果");
        //Debug.Log(obj);
        //Debug.Log("我们试一下用反射给字段赋值");
        ////var fi = type.GetField("id", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        //MethodInfo mi = type.GetMethod("Initialize");

        //mi.Invoke(obj, null);

    }
    private void GameApp_obj_Invoke(string name, params object[] param)
    {
        if (null != GameApp_obj)
        {
            var m = GameApp_type.GetMethod(name, 0);
            appdomain.Invoke(m, GameApp_obj, param);
        }
    }
}

