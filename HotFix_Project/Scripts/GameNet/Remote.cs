using GameBase;

namespace GameNet
{
    public class Remote : IRemote
    {
        public IModulesCollection CoreModules { get; set; }
        public Remote(RomoteType t)
        {
            type = t;
        }

        public RomoteType type { get; private set; }

        public IHeartBeat heartBeat { get; private set; }

        public IMsgProcess msgProcess { get; private set; }

        public IMsgReceiver msgReceriver { get; private set; }

        public IMsgSender msgSender { get; private set; }

        public IReconnect reconnect { get; private set; }

        public ISocket socket { get; private set; }
        public IMarshalEndian marshalEndian { get; private set; }

        private ServerInfo mInfo;
        public void Connect(ServerInfo info)
        {
            mInfo = info;
            this.socket.Connect(mInfo.ip, mInfo.port);
        }

        public void Disconnect()
        {
            this.socket.Disconnect();
        }

        public void Reconnect()
        {
            this.socket.Connect(mInfo.ip, mInfo.port);
        }

        public void SendMessage(IBaseMessage msg)
        {
            this.msgProcess.EnqueueSenderMsg(msg);
        }
        public void OnBuild(AbsRemoteBuilder builder)
        {
            this.heartBeat = builder.BuildHeartBeat();
            this.msgProcess = builder.BuildMsgProcess();
            this.msgReceriver = builder.BuildMsgReceriver();
            this.msgSender = builder.BuildMsgSender();
            this.reconnect = builder.BuildReconnect();
            this.socket = builder.BuildSocket();
            this.marshalEndian = builder.BuildMarshalEndian();
        }

        public bool IsConnected()
        {
            return this.socket.IsConnected(true);
        }

        public void Dispose()
        {
            heartBeat.Dispose();
            msgProcess.Dispose();
            msgReceriver.Dispose();
            msgSender.Dispose();
            reconnect.Dispose();
            socket.Dispose();
        }


        public void OnUpdate(float elapse)
        {
            msgProcess.OnUpdate(elapse);
        }
    }
}
