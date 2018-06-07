namespace GameNet
{
    public interface INetModule
    {
        void ConnectServer(ServerInfo info, RomoteType type);
        void DisconnectServer(RomoteType type);
        void ReconnectServer(RomoteType type);
        void SendMessage(IMessage msg);
    }
}
