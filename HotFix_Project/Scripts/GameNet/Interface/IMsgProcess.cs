
namespace GameNet
{
    using GameBase;

    public interface IMsgProcess: IRemoteHandler,IUpdate
    {
        void EnqueueSocketConnectState(SocketConnectState state);
    }
}
