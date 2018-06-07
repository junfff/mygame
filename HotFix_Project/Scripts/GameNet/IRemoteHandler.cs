namespace GameNet
{
    using GameBase;
    using System;

    public interface IRemoteHandler: IContext<IRemote>, IInitialize, IDisposable
    {

    }
}
