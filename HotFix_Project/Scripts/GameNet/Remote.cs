namespace GameNet
{
    public class Remote : IRemote
    {
        public Remote(RomoteType t)
        {
            type = t;
        }

        public RomoteType type { get; private set; }

        public IHeartBeat heartBeat { get; private set; }

        public IMsgProcess msgProcess { get; private set; }

        public IMsgReceriver msgReceriver { get; private set; }

        public IMsgSender msgSender { get; private set; }

        public IReconnect reconnect { get; private set; }

        public ISocket socket { get; private set; }
        private ServerInfo mInfo;
        public void Connect(ServerInfo info)
        {
            mInfo = info;
            this.socket.Connect(mInfo.ip, mInfo.port, mInfo.domain);
        }

        public void Disconnect()
        {
            this.socket.Disconnect();
        }

        public void Reconnect()
        {
            this.socket.Connect(mInfo.ip, mInfo.port, mInfo.domain);
        }

        public void SendMessage(IMessage msg)
        {
            this.msgSender.SendMsg(msg);
        }
        public void OnBuild(AbsRemoteBuilder builder)
        {
            this.heartBeat = builder.BuildHeartBeat();
            this.msgProcess = builder.BuildMsgProcess();
            this.msgReceriver = builder.BuildMsgReceriver();
            this.msgSender = builder.BuildMsgSender();
            this.reconnect = builder.BuildReconnect();
            this.socket = builder.BuildSocket();
        }

        public bool IsConnected()
        {
            return this.socket.IsConnected(true);
        }

        public void Dispose()
        {
           
        }
    }
}
