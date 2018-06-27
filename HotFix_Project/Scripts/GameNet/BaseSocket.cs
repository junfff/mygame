namespace GameNet
{
    using GameTimer;
    using System;
    using System.Net;
    using System.Net.Sockets;
    using UnityEngine;

    public class BaseSocket : ISocket
    {
        private const int bufferLength = 0x4000;
        private const int TimeOut = 6000;
        //private ITimer timer;
        private Socket mSocket;
        private SocketAsyncEventArgs mRevevent;
        private SocketState mState;
        private ArraySegment<byte> Buffer;
        public IRemote Context { get; set; }
        public virtual void Initialize()
        {
            //Socket(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType);
        }
        public bool Connect(string ip, int port)
        {
            if (this.IsConnecting())
            {
                Debug.LogErrorFormat("socket IsConnecting!!!");
                return false;
            }
            if (this.IsConnected(true))
            {
                Debug.LogErrorFormat("socket IsConnected!!!");
                return false;
            }
            if (string.IsNullOrEmpty(ip))
            {
                Debug.LogErrorFormat("socket IsNullOrEmpty ip!!!");
                return false;
            }
            if (null != mSocket)
            {
                this.Disconnect();
            }
            try
            {
                this.mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            catch (SocketException e)
            {
                Debug.LogErrorFormat("socket create failed : {0}", e.Message);
                return false;
            }
            //IPEndPoint(long address, int port);  IPEndPoint(IPAddress address, int port);
            this.mRevevent = new SocketAsyncEventArgs();
            this.mRevevent.RemoteEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            this.mRevevent.Completed += this.EventCompleted;
            mState = SocketState.CONNECTING;
            OnSocketState();
            try
            {
                this.mSocket.ConnectAsync(mRevevent);
            }
            catch (SocketException e)
            {
                Debug.LogErrorFormat("socket connectasync failed : {0}", e.Message);
                mState = SocketState.ERROR;
                OnSocketState();
                return false;
            }
            StartTimer();
            return true;
        }

        private void StartTimer()
        {
            Context.CoreModules.timerMDL.AddTimer(TimeOut, OnTimeOut);
        }

        private void OnTimeOut(int passedTime)
        {
            if (!this.IsConnected(true))
            {
                Debug.LogErrorFormat("socket OnTimeOut error : {0}", SocketError.TimedOut);
                this.Clear();
            }
        }

        public bool IsConnecting()
        {
            return mState == SocketState.CONNECTING;
        }

        private void EventCompleted(object sender, SocketAsyncEventArgs e)
        {
            //Debug.LogErrorFormat("EventCompleted LastOperation = {0}", e.LastOperation);
            if (e.LastOperation == SocketAsyncOperation.Connect)
            {
                this.ProcessConnect(sender as Socket, null, e);
            }
            else
            {
                ProcessReceive(e);
            }
        }

        private void ProcessConnect(Socket socket, object state, SocketAsyncEventArgs e)
        {
            if (e != null && e.SocketError != SocketError.Success)
            {
                Debug.LogErrorFormat("ProcessConnect SocketError : {0}", e.SocketError);
            }
            else
            {
                if (e == null)
                {
                    e = new SocketAsyncEventArgs();
                }
                if (this.Buffer.Array == null)
                {
                    //ArraySegment(T[] array, int offset, int count);
                    this.Buffer = new ArraySegment<byte>(new byte[bufferLength], 0, bufferLength);
                }
                e.SetBuffer(this.Buffer.Array, this.Buffer.Offset, this.Buffer.Count);
                this.mState = SocketState.CONNECTED;
                this.mSocket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);
                this.StartReceive();
                OnSocketState();
            }
        }

        private void ProcessReceive(SocketAsyncEventArgs e)
        {
            if (e.SocketError != SocketError.Success)
            {
                Debug.LogErrorFormat("ProcessReceive SocketError : {0}", e.SocketError);
            }
            else if (e.BytesTransferred <= 0)
            {
                Debug.LogErrorFormat("socket e.BytesTransferred <= 0 error : {0}", e.SocketError);
            }
            else
            {
                try
                {
                    Context.msgReceriver.OnRead(e.Buffer, e.Offset, e.BytesTransferred);
                }
                catch (Exception error)
                {
                    Debug.LogErrorFormat("socket ProcessReceive OnRead  error : {0}", error.Message);
                }
                StartReceive();
            }
        }

        private void StartReceive()
        {
            if (null != this.mSocket)
            {
                bool flag = false;
                try
                {
                    flag = this.mSocket.ReceiveAsync(this.mRevevent);
                }
                catch (Exception e)
                {
                    Debug.LogErrorFormat("socket ReceiveAsync  error : {0}", e.Message);
                    return;
                }
                if (!flag)
                {
                    this.ProcessReceive(this.mRevevent);
                }
            }
        }

        public void Disconnect()
        {
            if (null != this.mSocket)
            {
                if (null != this.mRevevent)
                {
                    this.mRevevent.Completed -= this.EventCompleted;
                    this.mRevevent.Dispose();
                    this.mRevevent = null;
                }

                try
                {
                    this.mSocket.Shutdown(SocketShutdown.Both);
                }
                catch
                {
                    this.mSocket.Close();
                }
                this.mSocket = null;
            }
        }

        public void Dispose()
        {
            this.Clear();
            Context = null;
        }



        public bool IsConnected(bool bPrecise)
        {
            if (null != mSocket)
            {
                if (this.mSocket.Connected)
                {
                    if (!bPrecise)
                    {
                        return true;
                    }
                    try
                    {
                        return !(this.mSocket.Poll(1000, SelectMode.SelectRead) && this.mSocket.Available == 0);
                    }
                    catch (Exception e)
                    {
                        Debug.LogErrorFormat("socket poll error: {0}", e.Message);
                        return false;
                    }
                }
            }
            return false;
        }

        public void Send(byte[] buff, int length)
        {
            if (this.IsConnected(true) && length > 0)
            {
                if (length > bufferLength)
                {
                    Debug.LogErrorFormat("socket send is out for range error");
                    return;
                }
                try
                {
                    //BeginSend(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback callback, object state);
                    this.mSocket.BeginSend(buff, 0, length, SocketFlags.None, null, this.mSocket);
                }
                catch (Exception e)
                {
                    Debug.LogErrorFormat("socket send error: {0}", e.Message);
                }
            }
        }

        public void Clear()
        {
            this.Disconnect();
        }


        private void OnSocketState(SocketError error = SocketError.Success)
        {
            Context.msgProcess.EnqueueSocketConnectState(new SocketConnectState(mState, error));
        }
    }
}
