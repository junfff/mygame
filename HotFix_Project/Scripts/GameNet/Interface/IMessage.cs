namespace GameNet
{
    public interface IMessage
    {
        RomoteType type { get; }
        byte[] GetByte();
        string GetString();
    }
}
