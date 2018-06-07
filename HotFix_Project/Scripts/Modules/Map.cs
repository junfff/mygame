

namespace GameBase
{
    using GameScene;
    using System;

    public class Map : IInitialize, IDisposable, IMap
    {
        private SceneType sceneType;
        public Map(SceneType sceneType)
        {
            this.sceneType = sceneType;
        }

        public void Dispose()
        {

        }

        public void Initialize()
        {

        }
    }
}