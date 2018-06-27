namespace GameNet
{
    using Google.Protobuf;
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using UnityEngine;

    /// <summary>
    /// 底层通信消息  
    /// </summary>
    public class BaseMessage : IBaseMessage
    {
        public RomoteType romoteType => RomoteType.LOGIN;//TODO
        /// <summary>
        /// 消息ID  
        /// </summary>
        public int MsgID { get; private set; }
        /// <summary>
        ///  消息内容  
        /// </summary>
        private MemoryStream stream;
        public int Length
        {
            get
            {
                return (int)stream.Length;
            }
        }
        public BaseMessage()
        {
            stream = new MemoryStream();
        }

        public void Clear()
        {
            stream.SetLength(0);
            stream.Position = 0;
        }

        public byte[] GetByte()
        {
            //return System.Text.Encoding.Default.GetBytes(obj); 
            return stream.ToArray();
        }
        public string GetString()
        {
            return System.Text.Encoding.Default.GetString(stream.ToArray());
        }

        public void WriteIn(int msgID ,byte[] buff, int offset, int length)
        {
            stream.Write(buff, offset, length);
        }

        public void WriteIn<T>(IMessage<T> message, int protobufId) where T : IMessage<T>
        {
            MsgID = protobufId;
            message.WriteTo(stream);
        }






        //        string类型转成byte[]：
        //byte[] byteArray = System.Text.Encoding.Default.GetBytes(str);
        //        byte[] 转成string：
        //string str = System.Text.Encoding.Default.GetString(byteArray);
    }
}
