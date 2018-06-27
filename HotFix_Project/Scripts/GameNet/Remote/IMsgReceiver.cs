namespace GameNet
{
    public interface IMsgReceiver: IRemoteHandler
    {
        void OnRead(byte[] buff,int offset,int length);
    }
}
