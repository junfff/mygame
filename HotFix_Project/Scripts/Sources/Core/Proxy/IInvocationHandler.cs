using System.Reflection;

namespace GameBase
{
    public interface IInvocationHandler
    {
        void PreProcess();
        object Invoke(object proxy, MethodInfo method, object[] args);
        void PostProcess();
    }
}
