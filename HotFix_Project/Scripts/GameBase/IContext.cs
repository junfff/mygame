namespace GameBase
{
    public interface IContext<T> where T : class
    {
        T Context { get; set; }
    }
}
