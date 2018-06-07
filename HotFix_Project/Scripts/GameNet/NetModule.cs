namespace GameNet
{
    using GameBase;
    using System.Collections.Generic;
    using UnityEngine;

    public class NetModule : BaseModule, INetModule
    {
        public override ModulesType moduleType => ModulesType.NET;
        public void ConnectServer(ServerInfo info, RomoteType type)
        {
            IRemote remote = Get(type);
            if (null == remote)
            {
                remote = RemoteFactory.Create(type);
                Add(remote);
            }
            remote.Connect(info);
        }



        public void DisconnectServer(RomoteType type)
        {
            IRemote remote = Get(type);
            if (null != remote)
            {
                remote.Disconnect();
            }
        }

        public void ReconnectServer(RomoteType type)
        {
            IRemote remote = Get(type);
            if (null != remote)
            {
                remote.Reconnect();
            }
        }

        public void SendMessage(IMessage msg)
        {
            IRemote remote = Get(msg.type);
            if (null != remote)
            {
                remote.SendMessage(msg);
            }
        }




        public override void Initialize()
        {
            base.Initialize();
            listRemote = new List<IRemote>();
            Debug.LogErrorFormat("On NetModule init !!!");
        }
        public override void Dispose()
        {
            base.Dispose();
            var enumerator = listRemote.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                item.Dispose();
            }
        }

        //*******************************
        private List<IRemote> listRemote;




        private void Add(IRemote remote)
        {
            if (null != remote)
            {
                listRemote.Add(remote);
            }
            else
            {
                Debug.LogErrorFormat("Add remote is null !!!");
            }
        }
        private IRemote Get(RomoteType type)
        {
            var enumerator = listRemote.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (item.type == type)
                {
                    return item;
                }
            }

            return null;
        }

    }
}
