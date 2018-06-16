namespace GameNet
{
    public interface IMessage
    {
        RomoteType romoteType { get; }
        byte[] GetByte();
        string GetString();
    }
}
