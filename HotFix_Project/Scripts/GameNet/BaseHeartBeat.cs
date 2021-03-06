﻿using ProtobufMsg;
using System;
using UnityEngine;

namespace GameNet
{
    public class BaseHeartBeat : IHeartBeat
    {
        private const int heartTime = 1000;
        private int heartNum;
        public IRemote Context { get; set; }
        private MsgHeartBeat p;

        public void Initialize()
        {
            p = new MsgHeartBeat();

            this.heartNum = 0;
        }
        public void Dispose()
        {
            this.RemoveTime();
        }
        private GameTimer.ITimer timer;
        public void OnUpdate(float elapse)
        {
            if (this.Context.socket.IsConnected(true))
            {
                this.AddTime();
            }
            else
            {
                if(this.RemoveTime())
                {
                    Debug.Log("断开连接，停止心跳！！");
                }
            }
        }
        private void AddTime()
        {
            if (this.timer == null)
            {
                this.timer = this.Context.CoreModules.timerMDL.AddTimer(heartTime, OnTime, true);
            }
        }
        private bool RemoveTime()
        {
            if (null != this.timer)
            {
                this.Context.CoreModules.timerMDL.RemoveTimer(this.timer);
                this.timer = null;
                return true;
            }
            return false;
        }
        private void OnTime(int passedTime)
        {
            this.heartNum++;
            //Debug.Log("心跳时间！！啵啵啵");

            p.ActionId = this.heartNum;
            p.T0 = DateTimeHelper.GetTimeStamp(false);
            
            IBaseMessage msg = ReceiverHelper.PopMessage();
            msg.WriteIn(p, DefineProtobuf.MSG_HEARTBEAT);
            this.Context.CoreModules.netMDL.SendMessage(msg);
        }
    }
}
