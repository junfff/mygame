namespace GameEvent
{
    using GameBase;

    public class EventModule : BaseModule, IEventModule
    {
        private MessageAggregator messageAggregator;
        public override void Initialize()
        {
            base.Initialize();
            messageAggregator = new MessageAggregator();
        }
        public override void Dispose()
        {
            base.Dispose();
            messageAggregator.Dispose();
        }

        public void Subscribe(int id, MessageHandler handler)
        {
            messageAggregator.Subscribe(id, handler);
        }

        public void UnSubscribe(int id, MessageHandler handler)
        {
            messageAggregator.UnSubscribe(id, handler);
        }

        public void Publish(int id, object param)
        {
            messageAggregator.Publish(id, param);
        }
    }
}
