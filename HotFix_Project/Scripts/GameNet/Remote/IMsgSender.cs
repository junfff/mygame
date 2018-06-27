namespace GameNet
{
    public interface IMsgSender : IRemoteHandler
    {
        void SendMsg(IBaseMessage msg);
    }
}
