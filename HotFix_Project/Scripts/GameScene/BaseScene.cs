namespace Modules.Scene
{
    using GameBase;
    using GameBusiness;
    using GameUtil;
    using System;
    using System.Collections;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public abstract class BaseScene : IScene
    {
        private Map map;
        public BusinessCollection businessCollection { get; private set; }
        //private SceneData data;
        public CoreUtil Core { get; private set; }

        public virtual SceneType sceneType
        {
            get
            {
                return SceneType.NONE;
            }
        }

        public IModulesCollection CoreModules { get; set; }

        public SceneStep sceneStep { get; set; }

        public Action<IScene> DoneCallBack { private get; set; }

        public virtual void Dispose()
        {
            Core.Dispose();
            map.Dispose();
            businessCollection.Dispose();
        }
        public virtual void Initialize()
        {
            businessCollection = new BusinessCollection();
            map = new Map(sceneType);
            Core = new CoreUtil(sceneType);

            Core.CoreModules = CoreModules;
            businessCollection.CoreModules = CoreModules;

            Core.Initialize();
            map.Initialize();
            businessCollection.Initialize();
        }

        public virtual void OnStart()
        {
            businessCollection.OnStart();
        }
        public virtual void OnEnd()
        {
            businessCollection.OnEnd();
        }

        public virtual void OnLateUpdate(float elapse)
        {
            businessCollection.OnLateUpdate(elapse);
        }

        public virtual void OnLoad()
        {

        }

        public virtual void OnUnLoad()
        {

        }

        public virtual void OnUpdate(float elapse)
        {

        }



        public void OnNextStep()
        {
            if (sceneStep == SceneStep.UNLOAD_DONE)
            {
                Debug.LogErrorFormat("OnNextStep error !!!");
                return;
            }
            sceneStep++;
            switch (sceneStep)
            {
                case SceneStep.NONE:
                    break;
                case SceneStep.LOAD_UNITY_SCENE:

                    GameRoot.instance.StartCoroutine(LoadScene(sceneType.ToString()));

                    break;
                case SceneStep.LOAD_DATA:

                    Initialize();
                    OnLoad();
                    OnNextStep();

                    break;
                case SceneStep.LOAD_DONE:

                    if (null != DoneCallBack)
                    {
                        DoneCallBack.Invoke(this);
                    }
                    OnStart();
                    break;


                case SceneStep.UNLOAD_DATE:

                    OnEnd();
                    OnUnLoad();
                    Dispose();
                    OnNextStep();

                    break;
                case SceneStep.UNLOAD_UNITY_SCENE:

                    GameRoot.instance.StartCoroutine(UnLoadScene(sceneType.ToString()));

                    break;
                case SceneStep.UNLOAD_DONE:
                    break;
            }

        }

        private AsyncOperation async_operation;

        //异步加载场景  
        IEnumerator LoadScene(string scene_name)
        {
            async_operation = SceneManager.LoadSceneAsync(scene_name, LoadSceneMode.Additive);
            //Debug.LogErrorFormat("LoadSceneAsync isDone = {0} ..............", async_operation.isDone);
            yield return async_operation;
            OnNextStep();
            //Debug.LogErrorFormat("LoadSceneAsync isDone = {0} >>>>>>>>>>>>", async_operation.isDone);
        }

        IEnumerator UnLoadScene(string scene_name)
        {
            async_operation = SceneManager.UnloadSceneAsync(scene_name);
            //Debug.LogErrorFormat("UnloadSceneAsync isDone = {0} ..............", async_operation.isDone);
            yield return async_operation;
            OnNextStep();
            //Debug.LogErrorFormat("UnloadSceneAsync isDone = {0} >>>>>>>>>>>>", async_operation.isDone);
        }

        public bool AddBusiness<T>() where T : IBusiness
        {
            return businessCollection.AddBusiness<T>();
        }

        public bool RemoveBusiness<T>() where T : IBusiness
        {
            return businessCollection.RemoveBusiness<T>();
        }

        public T CreateViewModel<T>() where T : ViewModelBase
        {
            return businessCollection.CreateViewModel<T>();
        }

        public T GetViewModel<T>() where T : ViewModelBase
        {
            return businessCollection.GetViewModel<T>();
        }
    }
}