namespace GameEvent
{
    using System.Collections.Generic;
    using UnityEngine;

    public delegate void MessageHandler(object param);
    public class MessageAggregator : IDisposable
    {
        private readonly Dictionary<int, MessageHandler> _messages = new Dictionary<int, MessageHandler>();

        public void Subscribe(int key, MessageHandler handler)
        {
            MessageHandler tmp = null;
            if (!_messages.TryGetValue(key, out tmp))
            {
                _messages.Add(key, handler);
            }
            else
            {
                _messages[key] += handler;
            }

        }
        public void UnSubscribe(int key, MessageHandler handler)
        {
            MessageHandler tmp = null;
            if (!_messages.TryGetValue(key, out tmp))
            {
                Debug.LogErrorFormat("UnSubscribe not find !! name = {0}", key);
                return;
            }
            else
            {
                _messages[key] -= handler;
            }

        }
        public void Publish(int key, object param)
        {
            if (_messages.ContainsKey(key) && _messages[key] != null)
            {
                //转发
                _messages[key](param);
            }
        }

        public void Dispose()
        {
            _messages.Clear();
        }
    }


}
