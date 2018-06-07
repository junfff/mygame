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

        }
    }
}
