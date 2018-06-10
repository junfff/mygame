namespace GameScene
{
    using GameBase;
    using GameScene;
    using System.Collections.Generic;
    using UnityEngine;

    public class SceneModule : BaseModule, ISceneModules
    {
        private List<IScene> listScene;
        private List<IScene> listRemove;
        public IScene curScene { get; private set; }
        public override ModulesType moduleType { get { return ModulesType.SCENE; } }

        public override void Initialize()
        {
            listScene = new List<IScene>();
            listRemove = new List<IScene>();

            RunScene(SceneType.Login);//TODO
        }

        public override void Dispose()
        {
            var enumerator = listScene.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;


            }

            listScene.Clear();
        }


        public int RunScene(SceneType type)
        {
            StopScene(curScene);

            IScene scene = SceneFactory.Create(type);
            scene.CoreModules = this.CoreModules;
            scene.sceneStep = SceneStep.NONE;
            scene.DoneCallBack = OnSceneDone;
            scene.OnNextStep();
            listScene.Add(scene);

            return 0;
        }
        public void OnSceneDone(IScene scene)
        {
            curScene = scene;
        }
        public int StopScene(SceneType type)
        {
            IScene scene = GetScene(type);
            return StopScene(scene);
        }
        public int StopScene(IScene scene)
        {
            if (null == scene)
            {
                return -1;
            }
            if (scene.sceneStep != SceneStep.LOAD_DONE)
            {
                Debug.LogErrorFormat("StopScene error !!!scene.sceneStep = {0}", scene.sceneStep);
                return -2;
            }
            scene.OnNextStep();

            return 0;
        }


        public IScene GetScene(SceneType type)
        {
            var enumerator = listScene.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (type == item.sceneType)
                {
                    return item;
                }
            }
            return null;
        }



        public override void OnUpdate(float elapse)
        {

            listRemove.Clear();
            var enumerator2 = listRemove.GetEnumerator();
            while (enumerator2.MoveNext())
            {
                var item = enumerator2.Current;
                if (listScene.Contains(item))
                {
                    listScene.Remove(item);
                }
            }

            var enumerator = listScene.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (item.sceneStep == SceneStep.LOAD_DONE)
                {
                    item.OnUpdate(elapse);
                }
                else if (item.sceneStep == SceneStep.UNLOAD_DONE)
                {
                    listRemove.Add(item);
                }
            }



        }

        public override void OnLateUpdate(float elapse)
        {
            var enumerator = listScene.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (item.sceneStep == SceneStep.LOAD_DONE)
                {
                    item.OnLateUpdate(elapse);
                }
            }
        }
    }
}