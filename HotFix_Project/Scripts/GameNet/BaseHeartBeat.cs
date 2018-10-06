using System;
using UnityEngine;

namespace GameNet
{
    public class BaseHeartBeat : IHeartBeat
    {
        private const int heartTime = 5000;
        private int heartNum;
        public IRemote Context { get; set; }
        public void Initialize()
        {
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
                this.RemoveTime();
            }
        }
        private void AddTime()
        {
            if (this.timer == null)
            {
                this.timer = this.Context.CoreModules.timerMDL.AddTimer(heartTime, OnTime, true);
            }
        }
        private void RemoveTime()
        {
            if (null != this.timer)
            {
                this.Context.CoreModules.timerMDL.RemoveTimer(this.timer);
                this.timer = null;
            }
        }
        private void OnTime(int passedTime)
        {
            this.heartNum++;
            Debug.Log("心跳时间！！啵啵啵");

            Person p = new Person();
            p.Name = "心跳时间！！啵啵啵 --- heartNum : " + this.heartNum;
            p.Email = "67449789@qq.com";
            p.Id = 123456789;

            IBaseMessage msg = ReceiverHelper.PopMessage();
            msg.WriteIn(p, DefineProtobuf.MSG_PERSON);
            this.Context.CoreModules.netMDL.SendMessage(msg);
        }
    }
}
