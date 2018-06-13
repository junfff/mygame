namespace GameNet
{
    using GameBase;
    using System.Net.Sockets;

    public class SocketConnectState : IClear
    {

        public SocketConnectState(SocketState mState, SocketError error)
        {
            this.socketState = mState;
            this.errorno = error;
        }

        public  SocketState socketState { get; set; }
        public SocketError errorno { get; set; }
        public void Clear()
        {
            errorno = SocketError.SocketError;
            socketState = SocketState.NONE;
        }
    }
}
