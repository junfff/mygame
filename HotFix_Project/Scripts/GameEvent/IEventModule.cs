namespace GameEvent
{
    public interface IEventModule
    {
        void Subscribe(int id, MessageHandler handler);
        void UnSubscribe(int id, MessageHandler handler);
        void Publish(int id, object param);
    }
}
