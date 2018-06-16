namespace GameNet
{
    using GameBase;
    using UnityEngine;

    public class MsgProcess : IMsgProcess
    {
        private ConcurrentLinkedQueue<SocketConnectState> socketStateQueue;
        public IRemote Context { get; set; }

        public void Dispose()
        {

        }

        public void Initialize()
        {
            socketStateQueue = new ConcurrentLinkedQueue<SocketConnectState>();
        }

        public void OnUpdate(float elapse)
        {
            SocketConnectState tmp = null;
            while (socketStateQueue.TryDequeue(out tmp))
            {
                Debug.LogFormat("SocketConnectState state = {0} error = {1}", tmp.socketState, tmp.errorno);
            }
        }

        public void EnqueueSocketConnectState(SocketConnectState state)
        {
            //socketStateQueue.Enqueue(state);
        }



    }
}
