using System;
using System.Collections.Generic;
using GameBase;
using Google.Protobuf;
using UnityEngine;

namespace GameNet
{
    public static class ReceiverHelper
    {
        private static ConcurrentLinkedQueue<IReceiver> receiverPool = new ConcurrentLinkedQueue<IReceiver>();
        private static ConcurrentLinkedQueue<IBaseMessage> msgPool = new ConcurrentLinkedQueue<IBaseMessage>();
        public static IBaseMessage PopMessage()
        {
            IBaseMessage msg = null;
            while (!msgPool.TryDequeue(out msg))
            {
                return CreateInstance<BaseMessage>();
            }
            return msg;
        }
        public static IReceiver PopReceiver()
        {
            IReceiver receiver = null;
            while (!receiverPool.TryDequeue(out receiver))
            {
                return CreateInstance<BaseReceiver>();
            }
            return receiver;
        }
        public static void RecycleMessage(IBaseMessage r)
        {
            if (null == r)
            {
                Debug.LogErrorFormat("On recycle IBaseMessage is null !!! ");
                return;
            }
            r.Clear();
            msgPool.Enqueue(r);
        }
        public static void RecycleReceiver(IReceiver r)
        {
            if (null == r)
            {
                Debug.LogErrorFormat("On recycle receiver is null !!! ");
                return;
            }
            r.Clear();
            receiverPool.Enqueue(r);
        }
        private static T CreateInstance<T>() where T : class
        {
            return System.Activator.CreateInstance<T>();
        }

        public static IMessage ParseFrom(IBaseMessage msg)
        {
            ////反序列化操作
            //Person p = Person.Parser.ParseFrom(msg.GetByte());
            switch (msg.MsgID)
            {
                case (int)DefineProtobuf.MSG_PERSON:
                    return Person.Parser.ParseFrom(msg.GetByte());
            }

            Debug.LogErrorFormat("ReceiverHelper ParseFrom not find parser  !!!! msgid = {0}", msg.MsgID);
            return null;
        }
    }
}
