using GameBase;
using Google.Protobuf;

namespace GameNet
{
    public interface IBaseMessage:IClear
    {
        RomoteType romoteType { get; }
        int Length { get; }
        int MsgID { get; }

        byte[] GetByte();
        string GetString();
        void WriteIn(int msgID, byte[] buff, int offset, int length);
        void WriteIn<T>(IMessage<T> message , int protobufId) where T : IMessage<T>;
    }
}
