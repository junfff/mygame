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
            BaseMessage msg = new BaseMessage();

            msg.WriteIn(buff, offset, length);

            Debug.LogErrorFormat("OnRead msg context = {0}  buff.Length = {1} offset = {2}", msg.GetString(), msg.Length, offset);

            //反序列化操作
            Person p = Person.Parser.ParseFrom(msg.GetByte());
            Debug.LogErrorFormat(">>>> name = {0} email = {1} id = {2} ", p.Name, p.Email, p.Id);
        }
    }
}
