using Google.Protobuf;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameNet
{
    public class MsgReceiver : IMsgReceiver
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
            Debug.LogFormat("============ Socket Read :  buff.Length = {0} offset = {1}", length, offset);

            List<IBaseMessage> list = Context.marshalEndian.Decode(buff, length);

            var enumerator = list.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                ProcessMsg(item);
                ReceiverHelper.RecycleMessage(item);
            }

        }

        private void ProcessMsg(IBaseMessage msg)
        {
            int size = msg.Length;
            int msgId = msg.MsgID;

            IMessage message = ReceiverHelper.ParseFrom(msg);

            if (null == message)
            {
                Debug.LogErrorFormat("MsgReceiver OnRead ParseFrom message is null !!!! msgid = {0}", msgId);
                return;
            }

            IReceiver receiver = ReceiverHelper.PopReceiver();
            if (null == receiver)
            {
                Debug.LogErrorFormat("MsgReceiver OnRead PopReceiver receiver is null !!!! msgid = {0}", msgId);
                return;
            }
            receiver.build(msgId, message, Context);

            Context.msgProcess.EnqueueReceiver(receiver);

            Debug.LogFormat("============ Socket Read :  msgId = {0} size = {1}", msgId, size);
        }
    }
}
