using UnityEngine;

namespace GameBase
{
    public class ConsoleContentWriter:IContentWriter
    {
        public void Write(string message)
        {
            Debug.Log("Console Log!:"+message);
        }
    }
}
