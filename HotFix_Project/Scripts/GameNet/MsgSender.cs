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

        public void SendMsg(IBaseMessage msg)
        {
            if (Context.IsConnected())
            {
                byte[] tmp = Context.marshalEndian.Encode(msg);

                if (msg.MsgID != DefineProtobuf.MSG_HEARTBEAT)
                {
                    Debug.LogFormat("============ Socket Send : ({0}) byte length : {1}   tmp[0]:{2} tmp[1]:{3}", 
                        msg.GetString(), tmp.Length,tmp[0].ToString("x8"),tmp[1].ToString("x8"));
                }
            
                Context.socket.Send(tmp, tmp.Length);
            }
            else
            {
                Debug.LogErrorFormat("socket not connected !!");
            }
        }
    }
}
