namespace GameNet
{
    using System;
    using Google.Protobuf;
    using GameEvent;
    public class BaseReceiver : IReceiver
    {
        public int ID { get; private set; }
        private IMessage _message;
        private IRemote _context;
        public void build(int msgId, IMessage message, IRemote context)
        {
            ID = msgId;
            _message = message;
            _context = context;
        }

        public void Clear()
        {
            ID = 0;
            _message = null;
            _context = null;
        }

        public void Process()
        {
            if (ID > 0)
            {
                _context.CoreModules.eventMDL.Publish(ID, _message);
            }
        }

    }
}
