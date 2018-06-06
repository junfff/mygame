using UnityEngine;

namespace GameBase
{
    public class DatabaseContentWriter : IContentWriter
    {
        public void Write(string message)
        {
            Debug.Log("Database Log!:"+message);
        }
    }
}
