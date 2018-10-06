namespace GameNet
{
    using GameBase;
    using GameEvent;
    using UnityEngine;

    public class MsgProcess : IMsgProcess
    {
        private ConcurrentLinkedQueue<SocketConnectState> socketStateQueue;
        private ConcurrentLinkedQueue<IReceiver> receiverQueue;
        private ConcurrentLinkedQueue<IBaseMessage> senderQueue;

        public IRemote Context { get; set; }

        public void Dispose()
        {

        }

        public void Initialize()
        {
            socketStateQueue = new ConcurrentLinkedQueue<SocketConnectState>();
            receiverQueue = new ConcurrentLinkedQueue<IReceiver>();
            senderQueue = new ConcurrentLinkedQueue<IBaseMessage>();
        }

        public void OnUpdate(float elapse)
        {
            SocketConnectState tmp = null;
            while (socketStateQueue.TryDequeue(out tmp))
            {
                Debug.LogFormat("SocketConnectState state = {0} error = {1}", tmp.socketState, tmp.errorno);
                this.Context.CoreModules.eventMDL.Publish(DefineEvent.EVENT_SOCKET_STATUS, tmp);
            }

            IReceiver receiver = null;
            while (receiverQueue.TryDequeue(out receiver))
            {
                //Debug.LogFormat("receiverQueue TryDequeue receiver ID = {0}", receiver.ID);
                receiver.Process();
                ReceiverHelper.RecycleReceiver(receiver);
            }

            IBaseMessage msg = null;
            while (senderQueue.TryDequeue(out msg))
            {
                Context.msgSender.SendMsg(msg);
                ReceiverHelper.RecycleMessage(msg);
            }
        }

        public void EnqueueSocketConnectState(SocketConnectState item)
        {
            socketStateQueue.Enqueue(item);
        }
        public void EnqueueReceiver(IReceiver item)
        {
            receiverQueue.Enqueue(item);
        }
        public void EnqueueSenderMsg(IBaseMessage msg)
        {
            senderQueue.Enqueue(msg);
        }

    }
}
