using UnityEngine;

namespace GameTimer
{
    public delegate void TimerPassedDelegate(int passedTime);
    public class BaseTimer : ITimer
    {
        private static int TimerInstanceID;

        private int m_expire;
        private TimerPassedDelegate m_callBack;
        private bool m_loop;
        private int current;
        public BaseTimer()
        {
            this.ID = TimerInstanceID++;
        }
        public bool Enable { get; private set; }
        public bool AutoRecycled { get; private set; }
        public int ID { get; private set; }

        public void Clear()
        {
            current = 0;
            m_expire = 0;
            m_callBack = null;
            m_loop = false;
            Enable = false;
            AutoRecycled = false;
        }

        public void Init(int expire, TimerPassedDelegate callBack, bool loop,bool autorecycled)
        {
            AutoRecycled = autorecycled;
            current = 0;
            m_expire = expire;
            m_callBack = callBack;
            m_loop = loop;
            Enable = expire > 0;
        }

        public void OnUpdate(float elapse)
        {
            if (Enable)
            {
                current += (int)(elapse * 1000);
                if (current >= m_expire)
                {
                    OnPassed();
                }

            }
        }

        public void Reset()
        {
            current = 0;
        }

        private void OnPassed()
        {
            if (null != m_callBack)
            {
                m_callBack.Invoke(current);
            }
            else
            {
                Debug.LogErrorFormat("OnPassed m_callBack = null!!!");
            }


            if (m_loop)
            {
                current = 0;
            }
            else
            {
                Clear();
            }
        }
    }
}
