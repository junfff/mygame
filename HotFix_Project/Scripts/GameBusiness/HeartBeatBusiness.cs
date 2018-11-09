namespace GameBusiness
{
    using GameBase;
    using GameEvent;
    using GameNet;
    using GameScene;
    using GameUI;
    using Google.Protobuf;
    using System;
    using System.IO;
    using UnityEngine;
    public class HeartBeatBusiness : BaseBusiness<HeartBeatModel>, IUpdate
    {
        public override void OnStart()
        {
            base.OnStart();
            base.businessCollection.CoreModules.eventMDL.Subscribe(DefineProtobuf.MSG_HEARTBEAT,OnHeartbeat);
        }
        public override void OnEnd()
        {
            base.OnEnd();
            base.businessCollection.CoreModules.eventMDL.Subscribe(DefineProtobuf.MSG_HEARTBEAT,OnHeartbeat);
        }

        private void OnHeartbeat(object param)
        {
            if (param is IMessage)
            {
                IMessage _message = param as IMessage;
                -_message.
            }
            
        }

    
        public override void OnUpdate(float elapse)
        {
        }

    }
}
