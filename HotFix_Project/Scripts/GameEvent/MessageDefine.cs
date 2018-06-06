using System;
using UnityEngine;

namespace GameEvent
{
    public static class MessageDefine
    {
        public static int Get(MessageHandler handler)
        {
            return handler.GetHashCode();
        }
        public static int Get(Action handler)
        {
            return handler.GetHashCode();
        }
    }
}
