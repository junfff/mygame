using UnityEngine;

namespace GameNet
{
    public class MsgSender : IMsgSender
    {
        private const int buffSize = 1024;
        private byte[] buff;
        public IRemote Context { get; set; }

        public void Dispose()
        {

        }

        public void Initialize()
        {
            this.buff = new byte[buffSize];
        }

        public void SendMsg(IMessage msg)
        {
            if (Context.IsConnected())
            {
                Context.socket.Send(buff, buffSize);
            }
            else
            {
                Debug.LogErrorFormat("socket not connected !!");
            }
        }
    }
}
