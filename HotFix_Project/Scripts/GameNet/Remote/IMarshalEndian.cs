using System.Collections.Generic;

namespace GameNet
{
   public interface IMarshalEndian: IRemoteHandler
    {
        byte[] Encode(IBaseMessage msg);
        List<IBaseMessage> Decode(byte[] buff, int len);
    }
}
