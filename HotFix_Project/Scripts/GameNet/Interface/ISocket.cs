namespace GameNet
{
    using GameBase;

    public interface ISocket : IRemoteHandler,IClear
    {
        bool Connect(string ip, int port, string domain);
        void Disconnect();
        bool IsConnected(bool bPrecise);
        void Send(byte[] buff, int buffSize);
        bool IsConnecting();
    }
}
