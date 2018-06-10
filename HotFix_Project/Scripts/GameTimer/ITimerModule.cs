
namespace GameTimer
{
    using GameBase;

    public interface ITimerModule:IClear
    {
        void AddTimer(int expire, TimerPassedDelegate callBack);
        ITimer AddTimer(int expire, TimerPassedDelegate callBack, bool loop);
        bool RemoveTimer(ITimer timer);

    }
}
