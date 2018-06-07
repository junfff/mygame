namespace GameNet
{
    public interface IMsgReceriver: IRemoteHandler
    {
        void OnRead(byte[] buff,int offset,int length);
    }
}
