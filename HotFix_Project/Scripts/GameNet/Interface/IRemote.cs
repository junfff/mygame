
namespace GameNet
{
    using GameBase;
    using System;
    public interface IRemote : IDisposable,IUpdate
    {
        IHeartBeat heartBeat { get; }
        IMsgProcess msgProcess { get; }
        IMsgReceriver msgReceriver { get; }
        IMsgSender msgSender { get; }
        IReconnect reconnect { get; }
        ISocket socket { get; }
        RomoteType type { get; }
        void Connect(ServerInfo info);
        void Disconnect();
        void Reconnect();
        void SendMessage(IMessage msg);
        bool IsConnected();
        void OnBuild(AbsRemoteBuilder builder);
        IModulesCollection CoreModules { get; set; }

    }
}
