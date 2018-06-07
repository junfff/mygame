namespace GameNet
{
    public interface IMsgSender : IRemoteHandler
    {
        void SendMsg(IMessage msg);
    }
}
