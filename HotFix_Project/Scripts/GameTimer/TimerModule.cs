namespace GameTimer
{
    using GameBase;
    using System.Collections.Generic;
    using UnityEngine;

    public class TimerModule : BaseModule, ITimerModule
    {
        public override ModulesType moduleType => ModulesType.TIMER;
        private List<ITimer> cachepool;
        private List<ITimer> removeList;

        private Dictionary<int, ITimer> dict;
        public override void Initialize()
        {
            base.Initialize();
            cachepool = new List<ITimer>();
            removeList = new List<ITimer>();
            dict = new Dictionary<int, ITimer>();
        }
        public override void Dispose()
        {
            base.Dispose();
            this.Clear();
        }
        /// <summary>
        /// autoRecycled
        /// </summary>
        public void AddTimer(int expire, TimerPassedDelegate callBack)
        {
            ITimer timer = Pop();
            timer.Init(expire, callBack, false, true);
            AddDict(timer);
        }
        public ITimer AddTimer(int expire, TimerPassedDelegate callBack, bool loop)
        {
            ITimer timer = Pop();
            timer.Init(expire, callBack, loop, false);
            AddDict(timer);
            return timer;
        }

        private void AddDict(ITimer timer)
        {
            ITimer tmp = null;
            if (!dict.TryGetValue(timer.ID, out tmp))
            {
                dict.Add(timer.ID, timer);
            }
            else
            {
                Debug.LogErrorFormat("repeated timer ID = {0}", timer.ID);
            }
        }

        private ITimer Pop()
        {
            ITimer timer = null;
            var enumerator = cachepool.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (!item.Enable)
                {
                    timer = item;
                }
            }
            if (null == timer)
            {
                timer = new BaseTimer();
            }
            return timer;
        }

        public bool RemoveTimer(ITimer timer)
        {
            if (null == timer)
            {
                Debug.Log("RemoveTimer is null !!");
                return false;
            }
            if(timer.AutoRecycled)
            {
                Debug.Log("AutoRecycled is timer !!");
                return false;
            }
            ITimer tmp = null;
            if (dict.TryGetValue(timer.ID, out tmp))
            {
                timer.Clear();
                dict.Remove(timer.ID);
                cachepool.Add(timer);
                return true;
            }
            return false;
        }

        public void Clear()
        {
            var enumerator = dict.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                item.Value.Clear();
            }
            cachepool.Clear();
            dict.Clear();
        }
        public override void OnUpdate(float elapse)
        {
            removeList.Clear();

            base.OnUpdate(elapse);
            var enumerator = dict.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                item.Value.OnUpdate(elapse);
                if (!item.Value.Enable && item.Value.AutoRecycled)
                {
                    removeList.Add(item.Value);
                }
            }

            var enumerator2 = removeList.GetEnumerator();
            while (enumerator2.MoveNext())
            {
                var item = enumerator2.Current;
                dict.Remove(item.ID);
                cachepool.Add(item);
            }
        }


    }
}
