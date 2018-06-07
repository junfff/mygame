namespace GameBusiness
{
    public interface IBusinessModule
    {
        bool AddBusiness<T>() where T : IBusiness;
        bool RemoveBusiness<T>() where T : IBusiness;
        void OnStart();
        void OnEnd();
 
    }
}
