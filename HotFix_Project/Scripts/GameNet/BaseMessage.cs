namespace GameNet
{
    using Google.Protobuf;
    using System;
    using System.IO;

    public class BaseMessage : IMessage
    {
        public BaseMessage()
        {
            stream = new MemoryStream();
        }
        public RomoteType romoteType => RomoteType.LOGIN;

        public int Length
        {
            get
            {
                return (int)stream.Length;
            }
        }


        private MemoryStream stream;

        public byte[] GetByte()
        {
            //return System.Text.Encoding.Default.GetBytes(obj); 
            return stream.ToArray();
        }

        public string GetString()
        {
            return System.Text.Encoding.Default.GetString(stream.ToArray());
        }

        public void WriteIn(byte[] buff, int offset, int length)
        {
            stream.Write(buff, offset, length);
        }

        public void WriteIn<T>(IMessage<T> message) where T : IMessage<T>
        {
            message.WriteTo(stream);
        }
        public void MergeTo<T>(IMessage<T> message) where T : IMessage<T>
        {
            message.MergeFrom(stream);
        }
        //        string类型转成byte[]：
        //byte[] byteArray = System.Text.Encoding.Default.GetBytes(str);
        //        byte[] 转成string：
        //string str = System.Text.Encoding.Default.GetString(byteArray);
    }
}
