
public interface IGameAppProxy
{
    void Init();
    void DisInit();
    void OnUpdate(float elapseTime);
    void OnLateUpdate(float elapseTime);
}

