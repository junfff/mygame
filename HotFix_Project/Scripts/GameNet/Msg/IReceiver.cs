namespace GameNet
{
    using GameBase;
    using Google.Protobuf;
    public interface IReceiver : IClear
    {
        int ID { get; }

        void Process();
        void build(int msgId, IMessage message, IRemote context);
    }
}
