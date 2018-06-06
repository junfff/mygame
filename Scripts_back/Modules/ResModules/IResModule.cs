
namespace Modules
{
    using Modules;
    public interface IResModule: IModules
    {
        T GetRes<T>(string path) where T : UnityEngine.Object;
        bool RecycleRes(UnityEngine.Object obj);
    }
}
