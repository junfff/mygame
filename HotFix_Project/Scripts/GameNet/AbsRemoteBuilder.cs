namespace GameNet
{
    public abstract class AbsRemoteBuilder : IRemoteBuilder
    {
        protected IRemote remote;

        public IRemote Create()
        {
            return remote;
        }
        public abstract ISocket BuildSocket();
        public abstract IHeartBeat BuildHeartBeat();
        public abstract IMsgProcess BuildMsgProcess();
        public abstract IMsgReceriver BuildMsgReceriver();
        public abstract IMsgSender BuildMsgSender();
        public abstract IReconnect BuildReconnect();
        protected T CreateInstance<T>() where T : IRemoteHandler
        {
            T t = System.Activator.CreateInstance<T>();
            t.Context = remote;
            t.Initialize();
            return t;
        }

    }
}
