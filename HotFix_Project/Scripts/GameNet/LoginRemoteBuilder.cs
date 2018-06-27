namespace GameNet
{
    public class LoginRemoteBuilder : AbsRemoteBuilder
    {
        public LoginRemoteBuilder()
        {
            remote = new Remote(RomoteType.LOGIN);
            remote.OnBuild(this);
        }

        public override IHeartBeat BuildHeartBeat()
        {
            return CreateInstance<BaseHeartBeat>();
        }

        public override IMsgProcess BuildMsgProcess()
        {
            return CreateInstance<MsgProcess>();
        }

        public override IMsgReceiver BuildMsgReceriver()
        {
            return CreateInstance<MsgReceiver>();
        }

        public override IMsgSender BuildMsgSender()
        {
            return CreateInstance<MsgSender>();
        }

        public override IReconnect BuildReconnect()
        {
            return CreateInstance<BaseReconnect>();
        }

        public override ISocket BuildSocket()
        {
            return CreateInstance<BaseSocket>();
        }
        public override IMarshalEndian BuildMarshalEndian()
        {
            return CreateInstance<MarshalEndian>();
        }


    }
}
