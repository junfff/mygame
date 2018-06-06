using UnityEngine;

namespace GameBase
{
    public class UserRepository:IUserRepository
    {
        public void Add()
        {
           Debug.Log("UserRepository");
        }
    }
}
