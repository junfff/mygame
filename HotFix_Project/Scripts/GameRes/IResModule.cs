
namespace GameRes
{
    using GameBase;
    public interface IResModule: IModules
    {
        T GetRes<T>(string path) where T : UnityEngine.Object;
        bool RecycleRes(UnityEngine.Object obj);
    }
}
