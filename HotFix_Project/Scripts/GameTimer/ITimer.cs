namespace GameTimer
{
    using GameBase;

    public interface ITimer : IClear, IUpdate
    {
        bool AutoRecycled { get; }
        bool Enable { get; }
        int ID { get; }

        void Init(int expire, TimerPassedDelegate callBack, bool loop, bool autoRecycled);
        void Reset();
    }
}
