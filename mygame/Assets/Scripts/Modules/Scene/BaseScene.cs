namespace Modules.Scene
{
    using GameUtil;
    using System;
    using System.Collections;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public abstract class BaseScene : IScene
    {

        //private SceneData data;
        protected CoreUtil coreUtil;
        private Map map;

        public virtual SceneType sceneType
        {
            get
            {
                return SceneType.NONE;
            }
        }

        public IModulesCollection CoreModules { get; set; }

        public SceneStep sceneStep { get; set; }

        public virtual void Dispose()
        {
            coreUtil.Dispose();
            map.Dispose();
        }

        public virtual void Initialize()
        {
            coreUtil = new CoreUtil(sceneType);
            coreUtil.CoreModules = CoreModules;
            coreUtil.Initialize();
            map = new Map(sceneType);
            map.Initialize();
        }


        public virtual void OnEnd()
        {

        }

        public virtual void OnLateUpdate(float elapse)
        {

        }

        public virtual void OnLoad()
        {

        }

        public virtual void OnStart()
        {

        }

        public virtual void OnUnLoad()
        {

        }

        public virtual void OnUpdate(float elapse)
        {
            if (null != async_operation)
            {
                //Debug.LogErrorFormat("async_operation idDone = {0} progress = {1}", async_operation.isDone, async_operation.progress);
                if (async_operation.isDone)
                {
                    OnUnitySceneDone();
                }
                async_operation = null;
            }
        }

        private void OnUnitySceneDone()
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

                    GameApp.instance.StartCoroutine(LoadScene(sceneType.ToString()));

                    break;
                case SceneStep.LOAD_DATA:

                    Initialize();
                    OnLoad();
                    OnStart();
                    OnNextStep();

                    break;
                case SceneStep.LOAD_DONE:
                    break;


                case SceneStep.UNLOAD_DATE:

                    OnEnd();
                    OnUnLoad();
                    Dispose();
                    OnNextStep();

                    break;
                case SceneStep.UNLOAD_UNITY_SCENE:

                    GameApp.instance.StartCoroutine(UnLoadScene(sceneType.ToString()));

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
    }
}