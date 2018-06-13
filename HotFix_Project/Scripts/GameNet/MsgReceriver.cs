using System;
using UnityEngine;

namespace GameNet
{
    public class MsgReceriver : IMsgReceriver
    {
        public IRemote Context { get; set; }

        public void Dispose()
        {

        }

        public void Initialize()
        {

        }
        public void OnRead(byte[] buff, int offset, int length)
        {
            Debug.LogErrorFormat("OnRead  buff = {0}  length = {1} offset = {2}", buff.ToString(), length, offset);
            BaseMessage msg = new BaseMessage();
            msg.byteArray = new byte[length];
            Array.Copy(buff, offset, msg.byteArray, 0, length);
            for (int i = 0; i < length; i++)
            {
                if (buff[i] != 0)
                {
                    Debug.LogErrorFormat("OnRead buff i = {0}  buff = {1}", i, buff[i]);
                }
            }
            Debug.LogErrorFormat("OnRead msg context = {0}  buff.Length = {1}", msg.GetString(), buff.Length);
        }
    }
}
