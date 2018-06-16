namespace GameNet
{
    public class BaseMessage : IMessage
    {
        public RomoteType romoteType => RomoteType.LOGIN;

        public string obj { get; internal set; }
        public byte[] byteArray { get; internal set; }

        public byte[] GetByte()
        {
            return System.Text.Encoding.Default.GetBytes(obj); ;
        }

        public string GetString()
        {
            return System.Text.Encoding.Default.GetString(byteArray);
        }
        //        string类型转成byte[]：
        //byte[] byteArray = System.Text.Encoding.Default.GetBytes(str);
        //        byte[] 转成string：
        //string str = System.Text.Encoding.Default.GetString(byteArray);
    }
}
