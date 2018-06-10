namespace GameTimer
{
    using GameBase;
    using System.Collections.Generic;

    public class TimerHandler : ITimerModule
    {
        private IModulesCollection CoreModules;
        private Dictionary<int, ITimer> dict;
        public TimerHandler(IModulesCollection cm)
        {
            CoreModules = cm;
            dict = new Dictionary<int, ITimer>();
        }
        public void AddTimer(int expire, TimerPassedDelegate callBack)
        {
            CoreModules.timerMDL.AddTimer(expire, callBack);
        }

        public ITimer AddTimer(int expire, TimerPassedDelegate callBack, bool loop)
        {
            ITimer tmp = CoreModules.timerMDL.AddTimer(expire, callBack, loop);
            dict.AddOrReplace(tmp.ID, tmp);
            return tmp;
        }

        public void Clear()
        {
            var enumerator = dict.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                RemoveTimer(item.Value);
            }
            dict.Clear();
        }

        public bool RemoveTimer(ITimer timer)
        {
            dict.TryRemove(timer.ID);
            return CoreModules.timerMDL.RemoveTimer(timer);
        }
    }
}
