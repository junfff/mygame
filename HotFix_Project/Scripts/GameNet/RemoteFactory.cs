namespace GameNet
{
    public static class RemoteFactory
    {
        public static IRemote Create(RomoteType type)
        {
            switch (type)
            {
                case RomoteType.LOGIN:
                    IRemoteBuilder builer = new LoginRemoteBuilder();
                    return builer.Create();

            }
            return null;
        }
    }
}
